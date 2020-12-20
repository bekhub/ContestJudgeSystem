using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContestJudgeSystem.Data;
using Models.Entities;
using ContestJudgeSystem.Infrastructure;
using ContestJudgeSystem.Models;
using Judge;
using Judge.Infrastructure;
using Models.Extensions;
using Models.Interfaces;

namespace ContestJudgeSystem.Services
{
    public class MainService
    {
        private DataContext Context { get; }
        
        private IFileProvider FileProvider { get; }

        public MainService(IFileProvider fileProvider, DataContext context)
        {
            FileProvider = fileProvider;
            Context = context;
        }
        
        public IEnumerable<SubmissionModel.List> Submissions()
        {
            return Context.Submissions.Select(x => new SubmissionModel.List
            {
                Id = x.Id,
                Language = x.Language.Name,
                Result = x.Result,
            });
        }

        public SubmissionModel.Get Submission(int id)
        {
            var submission = Context.Submissions.Find(id);
            return new SubmissionModel.Get
            {
                Language = submission.Language.Name,
                SourceCode = submission.SourceCode,
                Result = submission.Result,
                Results = submission.Results?.Select(x => x.Status.Description()),
                Mode = submission.Language.Mode,
            };
        }

        public IEnumerable<LanguageModel.List> Languages()
        {
            return Context.Languages.Where(x => x.IsActive).Select(x => new LanguageModel.List
            {
                Id = x.Id,
                Name = x.Name,
                Mode = x.Mode,
            });
        }

        public async Task ReceiveSubmission(SubmissionModel.Add model)
        {
            var submission = new Submission
            {
                LanguageId = model.LanguageId,
                SourceCode = model.SourceCode,
                Checker = model.Checker,
                CheckerType = model.CheckerType,
                Result = "Pending",
            };
            await Context.Submissions.AddAsync(submission);
            await Context.SaveChangesAsync();

            var language = await Context.Languages.FindAsync(submission.LanguageId);

            var runnable = language.RunnableEnum.GetRunnable();
            var checker = submission.CheckerType.GetChecker(FileProvider);
            var runner = Runner.GetInstance(FileProvider);
            var filename = submission.Id.ToString();
            var result = SaveFilesAsync(submission, model)
                .ContinueWith(_ => runner.Run(runnable, filename))
                .ContinueWith(_ => checker.Check(runnable, filename)).Result;

            submission.Result = result.StatusEnum.Description();

            Context.Submissions.Update(submission);
            await Context.SaveChangesAsync();

            var results = result.Results.Select(x => new Result
            {
                SubmissionId = submission.Id,
                Status = x,
            }).ToArray();

            if (results.Any())
            {
                await Context.Results.AddRangeAsync(results);
                await Context.SaveChangesAsync();
            }
        }

        private async Task SaveFilesAsync(Submission submission, SubmissionModel.Add model)
        {
            var inputPath = FileProvider.Inputs;
            var outputPath = FileProvider.Outputs;
            var sourceCodePath = $"{FileProvider.Sources}\\{submission.Id}.{submission.Language.FileExtension}";
            await File.WriteAllTextAsync(sourceCodePath, submission.SourceCode);
            Parallel.ForEach(model.Inputs, async (x, _, i) => await x.SaveFile($"{inputPath}\\{submission.Id}_{i}.txt"));
            Parallel.ForEach(model.Outputs, async (x, _, i) => await x.SaveFile($"{outputPath}\\{submission.Id}_{i}.txt"));
        }
    }
}
