using System.Data.Entity.ModelConfiguration;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Sql.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<QuestionEntity>
    {
        public QuestionConfiguration()
        {
            ToTable("Question");
            Property(e => e.Text).HasMaxLength(2000);
        }
    }
}
