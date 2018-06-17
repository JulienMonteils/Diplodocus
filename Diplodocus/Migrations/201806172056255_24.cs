namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SchoolSubjectMarks", "StudentIdStudent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolSubjectMarks", "StudentIdStudent", c => c.Int(nullable: false));
        }
    }
}
