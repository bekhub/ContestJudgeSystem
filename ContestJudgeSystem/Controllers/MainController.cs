using ContestJudgeSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContestJudgeSystem.Data;
using ContestJudgeSystem.Services;
using Models.Interfaces;

namespace ContestJudgeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private MainService Service { get; }
        
        public MainController(IFileProvider fileProvider, DataContext context)
        {
            Service = new MainService(fileProvider, context);
        }
        
        [HttpGet]
        [Route("submissions")]
        public IEnumerable<SubmissionModel.List> GetSubmissions()
        {
            return Service.Submissions();
        }

        [HttpGet]
        [Route("languages")]
        public IEnumerable<LanguageModel.List> Languages()
        {
            return Service.Languages();
        }
        
        [HttpGet]
        [Route("submission/{id}")]
        public SubmissionModel.Get GetSubmission(int id)
        {
            return Service.Submission(id);
        }
        
        [HttpPost]
        [Route("submission")]
        public async Task SendSubmission([FromBody] SubmissionModel.Add model)
        {
            await Service.ReceiveSubmission(model);
        }
    }
}
