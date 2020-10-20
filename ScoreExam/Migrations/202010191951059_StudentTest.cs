namespace ScoreExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 35),
                        Studentsubject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Studentsubjects", t => t.Studentsubject_Id)
                .Index(t => t.Studentsubject_Id);
            
            CreateTable(
                "dbo.Studentsubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjecId = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 50),
                        StudentId = c.Int(nullable: false),
                        Studentsubject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Studentsubjects", t => t.Studentsubject_Id)
                .Index(t => t.Studentsubject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Studentsubject_Id", "dbo.Studentsubjects");
            DropForeignKey("dbo.Students", "Studentsubject_Id", "dbo.Studentsubjects");
            DropIndex("dbo.Subjects", new[] { "Studentsubject_Id" });
            DropIndex("dbo.Students", new[] { "Studentsubject_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Studentsubjects");
            DropTable("dbo.Students");
        }
    }
}
