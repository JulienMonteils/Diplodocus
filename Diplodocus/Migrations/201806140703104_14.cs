namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolSubjectMarks", "GradeIdGrade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolSubjectMarks", "GradeIdGrade");
        }
    }
}
