namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Grade_IdGrade", "dbo.Grades");
            DropIndex("dbo.Students", new[] { "Grade_IdGrade" });
            RenameColumn(table: "dbo.Students", name: "Grade_IdGrade", newName: "GradeIdGrade");
            AlterColumn("dbo.Students", "GradeIdGrade", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "GradeIdGrade");
            AddForeignKey("dbo.Students", "GradeIdGrade", "dbo.Grades", "IdGrade", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GradeIdGrade", "dbo.Grades");
            DropIndex("dbo.Students", new[] { "GradeIdGrade" });
            AlterColumn("dbo.Students", "GradeIdGrade", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "GradeIdGrade", newName: "Grade_IdGrade");
            CreateIndex("dbo.Students", "Grade_IdGrade");
            AddForeignKey("dbo.Students", "Grade_IdGrade", "dbo.Grades", "IdGrade");
        }
    }
}
