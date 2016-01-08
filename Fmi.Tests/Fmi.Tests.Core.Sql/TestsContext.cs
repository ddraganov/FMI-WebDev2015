using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Fmi.Tests.Core.Sql.Configurations;
using Fmi.Tests.Core.Sql.Entities;
using Microsoft.WindowsAzure;

namespace Fmi.Tests.Core.Sql
{
    public class TestsContext : DbContext
    {
        public TestsContext()
            : base(CloudConfigurationManager.GetSetting("testsConnection"))
        {
        }

        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new TestConfiguration());
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestsContext, Migrations.Configuration>());
        }
    }
}
