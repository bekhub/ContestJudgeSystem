namespace ContestJudgeSystem.Models
{
    public class LanguageModel
    {
        public LanguageModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
    }
}