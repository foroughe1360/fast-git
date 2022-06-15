namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesignTrainingCourseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DesignTrainingCourseDates", "FinancialYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesignTrainingCourseDates", "FinancialYear");
        }
    }
}
