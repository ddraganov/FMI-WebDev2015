using System.Data.Entity;
using Fmi.Tests.Core.Sql.Configurations;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Sql
{
    public class TestsContext : DbContext
    {
        public TestsContext()
            : base("testsConnection")
        { }

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
