using System.Collections.Generic;
using Models.Enums;

namespace Models.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public RunnableEnum RunnableEnum { get; set; }

        public string Name { get; set; }

        public string FileExtension { get; set; }
        
        public bool IsActive { get; set; }
        
        public string Mode { get; set; }

        public virtual List<Submission> Submissions { get; set; }
    }
}
