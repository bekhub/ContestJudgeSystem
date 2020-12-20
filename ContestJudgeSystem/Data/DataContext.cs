using Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContestJudgeSystem.Data
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        
        public DbSet<Submission> Submissions { get; set; }
        
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
