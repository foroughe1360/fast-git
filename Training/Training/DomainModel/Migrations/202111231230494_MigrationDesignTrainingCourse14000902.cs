namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDesignTrainingCourse14000902 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DesignTrainingCourses", "EffectivenessOfCourse", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesignTrainingCourses", "EffectivenessOfCourse");
        }
    }
}
