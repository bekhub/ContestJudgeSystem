using System.Collections.Generic;
using Models.Enums;

namespace Models.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        
        public int LanguageId { get; set; }

        public string SourceCode { get; set; }

        public string Checker { get; set; }
        
        public CheckerEnum CheckerType { get; set; }

        public string Result { get; set; }

        public virtual IEnumerable<Result> Results { get; set; }

        public virtual Language Language { get; set; }
    }
}
