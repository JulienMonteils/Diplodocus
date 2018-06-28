namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gererModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Password", c => c.String());
            AlterColumn("dbo.Teachers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Teachers", "Address", c => c.String());
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "FirstName", c => c.String());
        }
    }
}
