namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            AddColumn("dbo.Users", "UserGUID", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.OJTLevels", "Description", c => c.String(maxLength: 1000));
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            AlterColumn("dbo.OJTLevels", "Description", c => c.String(maxLength: 500));
            DropColumn("dbo.Users", "RoleId");
            DropColumn("dbo.Users", "UserGUID");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
