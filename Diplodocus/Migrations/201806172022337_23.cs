namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolSubjectMarks", "StudentIdStudent", c => c.Int(nullable: false));
            AddColumn("dbo.SchoolSubjectMarks", "SchoolSubjectIdSchoolSubject", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolSubjectMarks", "SchoolSubjectIdSchoolSubject");
            DropColumn("dbo.SchoolSubjectMarks", "StudentIdStudent");
        }
    }
}
