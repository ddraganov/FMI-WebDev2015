using System.Data.Entity.ModelConfiguration;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Sql.Configurations
{
    public class TestConfiguration : EntityTypeConfiguration<TestEntity>
    {
        public TestConfiguration()
        {
            ToTable("Test");
            HasKey(e => e.Code);
            Property(e => e.Code).HasMaxLength(50);
            Property(e => e.Name).HasMaxLength(200).IsRequired();
            Property(e => e.Description).HasMaxLength(2000).IsOptional();
        }
    }
}
