namespace Fmi.Tests.Core.Sql.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 2000),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionEntity_Id)
                .Index(t => t.QuestionEntity_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.TestEntityQuestionEntities",
                c => new
                    {
                        TestEntity_Code = c.String(nullable: false, maxLength: 50),
                        QuestionEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestEntity_Code, t.QuestionEntity_Id })
                .ForeignKey("dbo.Test", t => t.TestEntity_Code, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.QuestionEntity_Id, cascadeDelete: true)
                .Index(t => t.TestEntity_Code)
                .Index(t => t.QuestionEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestEntityQuestionEntities", "QuestionEntity_Id", "dbo.Question");
            DropForeignKey("dbo.TestEntityQuestionEntities", "TestEntity_Code", "dbo.Test");
            DropForeignKey("dbo.Answer", "QuestionEntity_Id", "dbo.Question");
            DropIndex("dbo.TestEntityQuestionEntities", new[] { "QuestionEntity_Id" });
            DropIndex("dbo.TestEntityQuestionEntities", new[] { "TestEntity_Code" });
            DropIndex("dbo.Answer", new[] { "QuestionEntity_Id" });
            DropTable("dbo.TestEntityQuestionEntities");
            DropTable("dbo.Test");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
