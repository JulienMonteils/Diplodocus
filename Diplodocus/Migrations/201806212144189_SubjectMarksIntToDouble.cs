namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectMarksIntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SchoolSubjectMarks", "Mark", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SchoolSubjectMarks", "Mark", c => c.Int());
        }
    }
}
