namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssessmentOfTrainingServices", "TypeOfInstitutionId", c => c.Int(nullable: false));
            AddColumn("dbo.PlacementTabJobTrainings", "PostGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.PlacementTabJobTrainings", "DateStartPostGroupName", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PlacementTabJobTrainings", "PreviousJobs", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlacementTabJobTrainings", "PreviousJobs", c => c.String(maxLength: 100));
            DropColumn("dbo.PlacementTabJobTrainings", "DateStartPostGroupName");
            DropColumn("dbo.PlacementTabJobTrainings", "PostGroupId");
            DropColumn("dbo.AssessmentOfTrainingServices", "TypeOfInstitutionId");
        }
    }
}
