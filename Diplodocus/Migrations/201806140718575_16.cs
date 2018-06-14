namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolSubjectMarks", "Student_IdUser", "dbo.Students");
            DropIndex("dbo.SchoolSubjectMarks", new[] { "Student_IdUser" });
            RenameColumn(table: "dbo.SchoolSubjectMarks", name: "Student_IdUser", newName: "StudentIdUser");
            AlterColumn("dbo.SchoolSubjectMarks", "StudentIdUser", c => c.Int(nullable: false));
            CreateIndex("dbo.SchoolSubjectMarks", "StudentIdUser");
            AddForeignKey("dbo.SchoolSubjectMarks", "StudentIdUser", "dbo.Students", "IdUser", cascadeDelete: true);
            DropColumn("dbo.SchoolSubjectMarks", "StudentIdIdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolSubjectMarks", "StudentIdIdUser", c => c.Int(nullable: false));
            DropForeignKey("dbo.SchoolSubjectMarks", "StudentIdUser", "dbo.Students");
            DropIndex("dbo.SchoolSubjectMarks", new[] { "StudentIdUser" });
            AlterColumn("dbo.SchoolSubjectMarks", "StudentIdUser", c => c.Int());
            RenameColumn(table: "dbo.SchoolSubjectMarks", name: "StudentIdUser", newName: "Student_IdUser");
            CreateIndex("dbo.SchoolSubjectMarks", "Student_IdUser");
            AddForeignKey("dbo.SchoolSubjectMarks", "Student_IdUser", "dbo.Students", "IdUser");
        }
    }
}
