using Models.Enums;

namespace Models.DTO
{
    public class Result
    {
        public SubmissionStatusEnum StatusEnum { get; set; }

        public SubmissionStatusEnum[] Results { get; set; }
    }
}
