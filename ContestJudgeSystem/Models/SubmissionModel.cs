using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Models.Enums;

namespace ContestJudgeSystem.Models
{
    public class SubmissionModel
    {
        public class Add
        {
            public int LanguageId { get; set; }

            public string SourceCode { get; set; }

            public string Checker { get; set; }

            public CheckerEnum CheckerType { get; set; }

            public IEnumerable<IFormFile> Inputs { get; set; }
        
            public IEnumerable<IFormFile> Outputs { get; set; }
        }

        public class Get
        {
            public string Language { get; set; }

            public string SourceCode { get; set; }
            
            public string Result { get; set; }
            
            public IEnumerable<string> Results { get; set; }
            
            public string Mode { get; set; }
        }
        
        public class List
        {
            public int Id { get; set; }
            
            public string Language { get; set; }
            
            public string Result { get; set; }
        }
    }
}
