using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Sql.Configurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<AnswerEntity>
    {
        public AnswerConfiguration()
        {
            ToTable("Answer");
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Text).HasMaxLength(2000).IsRequired();
            Property(e => e.IsCorrect).IsRequired();
        }
    }
}
