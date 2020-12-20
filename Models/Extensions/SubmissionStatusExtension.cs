using Models.Enums;

namespace Models.Extensions
{
    public static class SubmissionStatusExtension
    {
        public static string Description(this SubmissionStatusEnum statusEnum) => statusEnum switch
        {
            SubmissionStatusEnum.Accepted => SubmissionStatusEnum.Accepted.ToString(),
            SubmissionStatusEnum.WrongAnswer => "Wrong answer",
            SubmissionStatusEnum.PresentationError => "Presentation error",
            _ => "Error",
        };
    }
}
