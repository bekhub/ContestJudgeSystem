using ContestJudgeSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContestJudgeSystem.Services;

namespace ContestJudgeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private MainService Service { get; }
        
        public MainController(MainService service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("languages")]
        public IEnumerable<LanguageModel> Languages() => new LanguageModel[] {
            new(0, "GNUC++17"), new(1, "Python 3"), new(2, "Java 14"), new(3, "C# 9"),
        };

        [HttpPost]
        [Route("submission")]
        public void SendSubmission([FromBody] SubmissionModel model)
        {
            Service.ReceiveSubmission(model);
        }
    }
}
