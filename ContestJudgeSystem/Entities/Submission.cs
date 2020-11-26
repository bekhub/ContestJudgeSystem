using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ContestJudgeSystem.Entities
{
    public class Submission
    {
        public int LanguageId { get; set; }

        public string SourceCode { get; set; }

        public IEnumerable<IFormFile> Inputs { get; set; }
        
        public IEnumerable<IFormFile> Outputs { get; set; }
    }
}
