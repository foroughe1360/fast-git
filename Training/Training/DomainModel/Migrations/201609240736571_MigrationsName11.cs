namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListResponsibilitiePowers",
                c => new
                    {
                        ListResponsibilitiePowerId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        PostGroupId = c.Int(nullable: false),
                        Description = c.String(),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListResponsibilitiePowerId);
            
            CreateTable(
                "dbo.RatingEvaluations",
                c => new
                    {
                        RatingEvaluationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        RatingEvaluationCoursesID = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        RatingEvaluationDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RatingEvaluationId);
            
            CreateTable(
                "dbo.TeacherLevelDates",
                c => new
                    {
                        TeacherLevelDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                        LevelDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherLevelDateId);
            
            AddColumn("dbo.TeacherLevels", "TeacherLevelDateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeacherLevels", "TeacherLevelDateId");
            DropTable("dbo.TeacherLevelDates");
            DropTable("dbo.RatingEvaluations");
            DropTable("dbo.ListResponsibilitiePowers");
        }
    }
}
