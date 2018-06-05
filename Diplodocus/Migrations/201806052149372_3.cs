namespace Diplodocus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Students");
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            DropColumn("dbo.Students", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Users");
            DropTable("dbo.Teachers");
            DropTable("dbo.Managers");
            RenameTable(name: "dbo.Students", newName: "Users");
        }
    }
}
