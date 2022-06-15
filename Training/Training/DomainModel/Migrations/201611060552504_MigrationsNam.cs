namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsNam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        RoleName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            AddColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Family");
            DropColumn("dbo.Users", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Family", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
