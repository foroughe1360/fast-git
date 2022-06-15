namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName38 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DesignTrainingCourses", "HoursHolding", c => c.Int(nullable: false));
            DropColumn("dbo.DesignTrainingCourses", "MinutesHolding");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DesignTrainingCourses", "MinutesHolding", c => c.Int(nullable: false));
            AlterColumn("dbo.DesignTrainingCourses", "HoursHolding", c => c.String(maxLength: 150));
        }
    }
}
