namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingPageFiles",
                c => new
                    {
                        TrainingPageFileId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DetialHistoryTrainingUploadPageId = c.Int(nullable: false),
                        FileScan = c.Binary(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingPageFileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrainingPageFiles");
        }
    }
}
