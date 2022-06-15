namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName27 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodingTrainings",
                c => new
                    {
                        CodingTrainingPageId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Title = c.String(maxLength: 50),
                        TrainingPageCode = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CodingTrainingPageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CodingTrainings");
        }
    }
}
