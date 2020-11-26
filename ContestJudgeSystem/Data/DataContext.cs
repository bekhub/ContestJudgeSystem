using ContestJudgeSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContestJudgeSystem.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        
        public DbSet<Submission> Submissions { get; set; }
    }
}
