namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListOfCorporateJobDates",
                c => new
                    {
                        ListOfCorporateJobDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                        LOCJDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListOfCorporateJobDateId);
            
            CreateTable(
                "dbo.OfferTrainingForJobDates",
                c => new
                    {
                        OfferTrainingForJobDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                        OTFJDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfferTrainingForJobDateId);
            
            CreateTable(
                "dbo.PlacementTabJobTrainingDates",
                c => new
                    {
                        PlacementTabJobTrainingDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                        PTJTDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlacementTabJobTrainingDateId);
            
            CreateTable(
                "dbo.TrainingCalendarDates",
                c => new
                    {
                        TrainingCalendarDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(),
                        TrCalendarDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingCalendarDateId);
            
            AddColumn("dbo.ListOfCorporateJobs", "ListOfCorporateJobDateId", c => c.Int(nullable: false));
            AddColumn("dbo.OfferTrainingForJobs", "OfferTrainingForJobDateId", c => c.Int(nullable: false));
            AddColumn("dbo.PlacementTabJobTrainings", "PlacementTabJobTrainingDateId", c => c.Int(nullable: false));
            AddColumn("dbo.TrainingCalendars", "TrainingCalendarDateId", c => c.Int(nullable: false));
            AddColumn("dbo.TrainingCalendars", "Participantlevel", c => c.String(maxLength: 500));
            DropColumn("dbo.TrainingCalendars", "ParticipantlevelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingCalendars", "ParticipantlevelId", c => c.Int(nullable: false));
            DropColumn("dbo.TrainingCalendars", "Participantlevel");
            DropColumn("dbo.TrainingCalendars", "TrainingCalendarDateId");
            DropColumn("dbo.PlacementTabJobTrainings", "PlacementTabJobTrainingDateId");
            DropColumn("dbo.OfferTrainingForJobs", "OfferTrainingForJobDateId");
            DropColumn("dbo.ListOfCorporateJobs", "ListOfCorporateJobDateId");
            DropTable("dbo.TrainingCalendarDates");
            DropTable("dbo.PlacementTabJobTrainingDates");
            DropTable("dbo.OfferTrainingForJobDates");
            DropTable("dbo.ListOfCorporateJobDates");
        }
    }
}
