namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PostGroups", name: "TypeOfEvaluationId", newName: "PostGroupId");
            CreateTable(
                "dbo.DetailPlacementTabJobTrainings",
                c => new
                    {
                        DetailPlacementTabJobTrainingId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        PlacementTabJobTrainingId = c.Int(nullable: false),
                        Title = c.String(),
                        FinalComment = c.String(),
                        NumberOfHours = c.Int(nullable: false),
                        OJTLevelId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetailPlacementTabJobTrainingId);
            
            CreateTable(
                "dbo.FileRepositories",
                c => new
                    {
                        FileRepositoryId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        ContentId = c.Int(nullable: false),
                        FileName = c.String(maxLength: 50),
                        ContentType = c.String(maxLength: 50),
                        ContentLength = c.Binary(),
                        FileFormId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FileRepositoryId);
            
            CreateTable(
                "dbo.OJTLevels",
                c => new
                    {
                        OJTLevelId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        LevelNumber = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OJTLevelId);
            
            CreateTable(
                "dbo.PlacementTabJobTrainings",
                c => new
                    {
                        PlacementTabJobTrainingId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlacementTabJobTrainingId);
            
            CreateTable(
                "dbo.SignatureResponsibilities",
                c => new
                    {
                        SignatureResponsibilityId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Signature = c.Binary(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SignatureResponsibilityId);
            
            AddColumn("dbo.CourseObjectivesEffectivenessTrainings", "AmountAccessPurposeId", c => c.Int(nullable: false));
            AddColumn("dbo.EffectivenessTrainings", "CourseRegistrationId", c => c.Int(nullable: false));
            AddColumn("dbo.EffectivenessTrainings", "EffectivenessTrainingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EffectivenessTrainings", "CorrectiveactionDescription", c => c.String());
            AddColumn("dbo.EmployemeJobs", "DateStartPostGroupName", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployemeJobs", "ActivePostGroupName", c => c.Boolean(nullable: false));
            AddColumn("dbo.EvaluationTrainingPrograms", "CourseRegistrationId", c => c.Int(nullable: false));
            AddColumn("dbo.Inventoryjobs", "Education", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "VCode", c => c.String(maxLength: 50));
            DropColumn("dbo.EffectivenessTrainings", "EmployemesId");
            DropColumn("dbo.EffectivenessTrainings", "EffectivenessOfCoursesId");
            DropColumn("dbo.EvaluationTrainingPrograms", "DesignTrainingCourseId");
            DropColumn("dbo.EvaluationTrainingPrograms", "ScoreEducationIdForDirectorEducationQuestionId");
            DropColumn("dbo.EvaluationTrainingPrograms", "EmployemesId");
            DropColumn("dbo.Inventoryjobs", "EducationId");
            DropColumn("dbo.Inventoryjobs", "FieldOfStudy");
            DropColumn("dbo.Inventoryjobs", "AcademicOrientation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventoryjobs", "AcademicOrientation", c => c.String(maxLength: 50));
            AddColumn("dbo.Inventoryjobs", "FieldOfStudy", c => c.String(maxLength: 50));
            AddColumn("dbo.Inventoryjobs", "EducationId", c => c.Int(nullable: false));
            AddColumn("dbo.EvaluationTrainingPrograms", "EmployemesId", c => c.Int(nullable: false));
            AddColumn("dbo.EvaluationTrainingPrograms", "ScoreEducationIdForDirectorEducationQuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.EvaluationTrainingPrograms", "DesignTrainingCourseId", c => c.Int(nullable: false));
            AddColumn("dbo.EffectivenessTrainings", "EffectivenessOfCoursesId", c => c.Int(nullable: false));
            AddColumn("dbo.EffectivenessTrainings", "EmployemesId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "VCode");
            DropColumn("dbo.Inventoryjobs", "Education");
            DropColumn("dbo.EvaluationTrainingPrograms", "CourseRegistrationId");
            DropColumn("dbo.EmployemeJobs", "ActivePostGroupName");
            DropColumn("dbo.EmployemeJobs", "DateStartPostGroupName");
            DropColumn("dbo.EffectivenessTrainings", "CorrectiveactionDescription");
            DropColumn("dbo.EffectivenessTrainings", "EffectivenessTrainingDate");
            DropColumn("dbo.EffectivenessTrainings", "CourseRegistrationId");
            DropColumn("dbo.CourseObjectivesEffectivenessTrainings", "AmountAccessPurposeId");
            DropTable("dbo.SignatureResponsibilities");
            DropTable("dbo.PlacementTabJobTrainings");
            DropTable("dbo.OJTLevels");
            DropTable("dbo.FileRepositories");
            DropTable("dbo.DetailPlacementTabJobTrainings");
            RenameColumn(table: "dbo.PostGroups", name: "PostGroupId", newName: "TypeOfEvaluationId");
        }
    }
}
