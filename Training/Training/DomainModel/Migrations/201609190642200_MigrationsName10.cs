namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DesignTrainingCourses", "CourseObjectives", c => c.String(maxLength: 1500));
            AlterColumn("dbo.DesignTrainingCourses", "CourseContent", c => c.String(maxLength: 1500));
            AlterColumn("dbo.DesignTrainingCourses", "OtherNotes", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DesignTrainingCourses", "OtherNotes", c => c.String(maxLength: 2000));
            AlterColumn("dbo.DesignTrainingCourses", "CourseContent", c => c.String(maxLength: 2000));
            AlterColumn("dbo.DesignTrainingCourses", "CourseObjectives", c => c.String(maxLength: 2000));
        }
    }
}
