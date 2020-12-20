using Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContestJudgeSystem.Data
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.RunnableEnum).HasConversion<byte>();
            builder.HasMany(x => x.Submissions).WithOne(x => x.Language);
        }
    }
}
