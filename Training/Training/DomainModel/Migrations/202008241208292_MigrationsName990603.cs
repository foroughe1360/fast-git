namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName990603 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployemeSignaturies",
                c => new
                    {
                        NameOfSignatoryId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        SideSignatoryId = c.Int(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        NameOfSignatoryDate = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NameOfSignatoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployemeSignaturies");
        }
    }
}
