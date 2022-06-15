namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseRegistrations", "EmployemeStateID", c => c.Int(nullable: false));
            AddColumn("dbo.DesignTrainingCourses", "TypesOfTrainingId", c => c.Int(nullable: false));
            AddColumn("dbo.DesignTrainingCourses", "MaximumScore", c => c.Int(nullable: false));
            DropColumn("dbo.DesignTrainingCourses", "PurposeTest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DesignTrainingCourses", "PurposeTest", c => c.String(maxLength: 50));
            DropColumn("dbo.DesignTrainingCourses", "MaximumScore");
            DropColumn("dbo.DesignTrainingCourses", "TypesOfTrainingId");
            DropColumn("dbo.CourseRegistrations", "EmployemeStateID");
        }
    }
}
