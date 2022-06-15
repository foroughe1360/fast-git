namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName37 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.DesignTrainingCourses", "MinutesHolding", c => c.Int(nullable: false));
            //AlterColumn("dbo.DesignTrainingCourses", "HoursHolding", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.DesignTrainingCourses", "HoursHolding", c => c.Int(nullable: false));
            //DropColumn("dbo.DesignTrainingCourses", "MinutesHolding");
        }
    }
}
