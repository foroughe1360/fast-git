namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NameOfSignatories",
                c => new
                    {
                        NameOfSignatoryId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        SideSignatoryId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        NameOfSignatoryDate = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NameOfSignatoryId);
            
            CreateTable(
                "dbo.SideSignatories",
                c => new
                    {
                        SideSignatoryId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Title = c.String(maxLength: 50),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SideSignatoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SideSignatories");
            DropTable("dbo.NameOfSignatories");
        }
    }
}
