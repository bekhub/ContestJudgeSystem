using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Models.DTO;
using Models.Enums;
using Models.Interfaces;

namespace Judge.Checkers
{
    public class DefaultChecker : IChecker
    {
        private IFileProvider FileProvider { get; }

        private const string Txt = "txt";

        public DefaultChecker(IFileProvider fileProvider)
        {
            FileProvider = fileProvider;
        }

        public Result Check(IRunnable runnable, string filename)
        {
            var outputs = FileProvider.Outputs.GetFiles(filename, Txt)
                .OrderBy(x => x.Name.GetFileOrder()).Select(x => x.Text.Trim()).ToArray();
            var realOutputs = FileProvider.RealOutputs.GetFiles(filename, Txt)
                .OrderBy(x => x.Name.GetFileOrder()).Select(x => x.Text.Trim()).ToArray();

            if (outputs.Length != realOutputs.Length)
                return new Result { StatusEnum = SubmissionStatusEnum.PresentationError };
            
            var results = outputs
                .Select((t, i) => t == realOutputs[i] ? SubmissionStatusEnum.Accepted : SubmissionStatusEnum.WrongAnswer)
                .ToArray();

            var status = results.Any(x => x == SubmissionStatusEnum.WrongAnswer) 
                ? SubmissionStatusEnum.WrongAnswer
                : SubmissionStatusEnum.Accepted;

            return new Result
            {
                StatusEnum = status,
                Results = results,
            };
        }
    }
}
