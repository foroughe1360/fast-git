namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName990615 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SetDateForRepors",
                c => new
                    {
                        SetDateForReportId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        ReportNameId = c.Int(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        PublicCode = c.Int(nullable: false),
                        DateOfProducer = c.DateTime(nullable: false),
                        DateOfApprover = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SetDateForReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SetDateForRepors");
        }
    }
}
