using Models.Enums;

namespace Models.Entities
{
    public class Result
    {
        public int Id { get; set; }

        public int SubmissionId { get; set; }
        
        public virtual Submission Submission { get; set; }

        public SubmissionStatusEnum Status { get; set; }

        public string ErrorDescription { get; set; }
    }
}
