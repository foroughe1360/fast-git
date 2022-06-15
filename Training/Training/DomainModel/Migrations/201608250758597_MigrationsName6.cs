namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ListAbilityRequiredJobs", name: "DetailOfferTrainingForJobId", newName: "ListAbilityRequiredJobId");
            CreateTable(
                "dbo.ListTypeTestScores",
                c => new
                    {
                        ListTypeTestScoreId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        VarietyOfTestId = c.Int(nullable: false),
                        ExamDates = c.DateTime(nullable: false),
                        PurposeTest = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListTypeTestScoreId);
            
            AddColumn("dbo.Inventoryjobs", "PostGroupName", c => c.String(maxLength: 50));
            AddColumn("dbo.ListHealthConditions", "Description", c => c.String(maxLength: 1000));
            AddColumn("dbo.TestScores", "ListTypeTestScoresId", c => c.Int(nullable: false));
            AlterColumn("dbo.Attendances", "HourDelayFrom", c => c.String(maxLength: 50));
            AlterColumn("dbo.Attendances", "HourDelayTo", c => c.String());
            DropColumn("dbo.Inventoryjobs", "UnitSCenterId");
            DropColumn("dbo.Inventoryjobs", "DepartmentId");
            DropColumn("dbo.Inventoryjobs", "PostGroupId");
            DropColumn("dbo.TestScores", "VarietyOfTestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestScores", "VarietyOfTestId", c => c.Int(nullable: false));
            AddColumn("dbo.Inventoryjobs", "PostGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.Inventoryjobs", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Inventoryjobs", "UnitSCenterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Attendances", "HourDelayTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "HourDelayFrom", c => c.DateTime(nullable: false));
            DropColumn("dbo.TestScores", "ListTypeTestScoresId");
            DropColumn("dbo.ListHealthConditions", "Description");
            DropColumn("dbo.Inventoryjobs", "PostGroupName");
            DropTable("dbo.ListTypeTestScores");
            RenameColumn(table: "dbo.ListAbilityRequiredJobs", name: "ListAbilityRequiredJobId", newName: "DetailOfferTrainingForJobId");
        }
    }
}
