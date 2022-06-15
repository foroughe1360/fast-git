namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssessmentOfTrainingServices", "Address", c => c.String(maxLength: 500));
            AddColumn("dbo.PlacementTabJobTrainings", "PreviousJobs", c => c.String(maxLength: 100));
            AddColumn("dbo.TablesRelatedAssessmentOfTrainingServices", "Value", c => c.String(maxLength: 50));
            AlterColumn("dbo.DetailPlacementTabJobTrainings", "NumberOfHours", c => c.Double(nullable: false));
            DropColumn("dbo.AssessmentOfTrainingServices", "Adress");
            DropColumn("dbo.TablesRelatedAssessmentOfTrainingServices", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TablesRelatedAssessmentOfTrainingServices", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.AssessmentOfTrainingServices", "Adress", c => c.String());
            AlterColumn("dbo.DetailPlacementTabJobTrainings", "NumberOfHours", c => c.Int(nullable: false));
            DropColumn("dbo.TablesRelatedAssessmentOfTrainingServices", "Value");
            DropColumn("dbo.PlacementTabJobTrainings", "PreviousJobs");
            DropColumn("dbo.AssessmentOfTrainingServices", "Address");
        }
    }
}
