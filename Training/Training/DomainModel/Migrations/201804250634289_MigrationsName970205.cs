namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName970205 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailOfferTrainingForEmployemes",
                c => new
                    {
                        DetailOfferTrainingForEmployemeId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        OfferTrainingForEmployemesId = c.Int(nullable: false),
                        NeedTraining = c.String(),
                        PriorityId = c.Int(nullable: false),
                        TableTypeOfTrainingOfferId = c.Int(nullable: false),
                        TableTypeOfTrainingSetId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetailOfferTrainingForEmployemeId);
            
            CreateTable(
                "dbo.OfferTrainingForEmployeeDates",
                c => new
                    {
                        OfferTrainingForEmployeeDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                        OTFJDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfferTrainingForEmployeeDateId);
            
            CreateTable(
                "dbo.OfferTrainingForEmployemes",
                c => new
                    {
                        OfferTrainingForEmployemeId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        OfferTrainingForEmployeeDateId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        PostGroupId = c.Int(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        DateNeeds = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfferTrainingForEmployemeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OfferTrainingForEmployemes");
            DropTable("dbo.OfferTrainingForEmployeeDates");
            DropTable("dbo.DetailOfferTrainingForEmployemes");
        }
    }
}
