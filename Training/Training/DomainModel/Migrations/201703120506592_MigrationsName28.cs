namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName28 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetialHistoryTrainingUploadPages",
                c => new
                    {
                        DetialHistoryTrainingUploadPageId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        HistoryTrainingUploadPageId = c.Int(nullable: false),
                        CodingTrainingPageId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetialHistoryTrainingUploadPageId);
            
            CreateTable(
                "dbo.HistoryTrainingUploadPages",
                c => new
                    {
                        HistoryTrainingUploadPageId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        HTUPDescripption = c.String(maxLength: 500),
                        HistoryTrainingUploadPageDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryTrainingUploadPageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HistoryTrainingUploadPages");
            DropTable("dbo.DetialHistoryTrainingUploadPages");
        }
    }
}
