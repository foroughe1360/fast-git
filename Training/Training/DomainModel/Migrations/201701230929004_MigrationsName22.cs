namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherLevels", "TrainingCourse", c => c.String(maxLength: 50));
            AlterColumn("dbo.TeacherLevels", "EffectivenessOfPreviousPeriod", c => c.Double(nullable: false));
            AlterColumn("dbo.TeacherLevels", "Rhetorical", c => c.Double(nullable: false));
            AlterColumn("dbo.TeacherLevels", "EducationId", c => c.Double(nullable: false));
            AlterColumn("dbo.TeacherLevels", "Experience", c => c.Double(nullable: false));
            AlterColumn("dbo.TeacherLevels", "CoursePlan", c => c.Double(nullable: false));
            AlterColumn("dbo.TeacherLevels", "HistoryOfCooperation", c => c.Double(nullable: false));
            AlterColumn("dbo.TeacherLevels", "Degree", c => c.Double(nullable: false));
            DropColumn("dbo.TeacherLevels", "TrainingCourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeacherLevels", "TrainingCourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "Degree", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "HistoryOfCooperation", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "CoursePlan", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "Experience", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "EducationId", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "Rhetorical", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherLevels", "EffectivenessOfPreviousPeriod", c => c.Int(nullable: false));
            DropColumn("dbo.TeacherLevels", "TrainingCourse");
        }
    }
}
