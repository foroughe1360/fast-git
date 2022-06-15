namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListOfCorporateJobs",
                c => new
                    {
                        ListOfCorporateJobId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CollectionId = c.Int(nullable: false),
                        PostTypeId = c.Int(nullable: false),
                        NumberOfPeopleEmployed = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Year = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListOfCorporateJobId);
            
            CreateTable(
                "dbo.TrainingCalendars",
                c => new
                    {
                        TrainingCalendarId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        CourseName = c.String(),
                        TeacherId = c.Int(nullable: false),
                        ParticipantlevelId = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        TrainingCalendarDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingCalendarId);
            
            AddColumn("dbo.ListTrainingRequireds", "TitleTraining", c => c.String());
            AddColumn("dbo.ListTrainingRequireds", "SDTime", c => c.Int(nullable: false));
            AddColumn("dbo.ListTrainingRequireds", "OJTTime", c => c.Int(nullable: false));
            AddColumn("dbo.ListTrainingRequireds", "CTime", c => c.Int(nullable: false));
            DropColumn("dbo.ListTrainingRequireds", "TrainingRequiredId");
            DropColumn("dbo.ListTrainingRequireds", "TableTypeOfTrainingTimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListTrainingRequireds", "TableTypeOfTrainingTimeId", c => c.Int(nullable: false));
            AddColumn("dbo.ListTrainingRequireds", "TrainingRequiredId", c => c.Int(nullable: false));
            DropColumn("dbo.ListTrainingRequireds", "CTime");
            DropColumn("dbo.ListTrainingRequireds", "OJTTime");
            DropColumn("dbo.ListTrainingRequireds", "SDTime");
            DropColumn("dbo.ListTrainingRequireds", "TitleTraining");
            DropTable("dbo.TrainingCalendars");
            DropTable("dbo.ListOfCorporateJobs");
        }
    }
}
