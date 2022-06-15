namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DesignTrainingCourses", "HoursHolding", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesignTrainingCourses", "HoursHolding");
        }
    }
}
