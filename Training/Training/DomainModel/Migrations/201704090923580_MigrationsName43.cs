namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DesignTrainingCourses", "MinutesHolding", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesignTrainingCourses", "MinutesHolding");
        }
    }
}
