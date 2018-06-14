namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolSubjectMarks", "StudentIdIdUser", c => c.Int(nullable: false));
            DropColumn("dbo.SchoolSubjectMarks", "GradeIdGrade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolSubjectMarks", "GradeIdGrade", c => c.Int(nullable: false));
            DropColumn("dbo.SchoolSubjectMarks", "StudentIdIdUser");
        }
    }
}
