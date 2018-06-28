namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Grades", "gradeName", c => c.String(nullable: false));
            AlterColumn("dbo.Managers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Managers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Managers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Managers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.SchoolSubjectMarks", "Mark", c => c.Double(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "AddressMail", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Students", "AddressMail", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.SchoolSubjectMarks", "Mark", c => c.Double());
            AlterColumn("dbo.Managers", "Password", c => c.String());
            AlterColumn("dbo.Managers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Managers", "LastName", c => c.String());
            AlterColumn("dbo.Managers", "FirstName", c => c.String());
            AlterColumn("dbo.Grades", "gradeName", c => c.String());
        }
    }
}
