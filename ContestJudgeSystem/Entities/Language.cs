namespace ContestJudgeSystem.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompilerPath { get; set; }

        public bool IsActive { get; set; }
    }
}
