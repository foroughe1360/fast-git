namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeTrainingPasseds", "Duration", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeTrainingPasseds", "Duration", c => c.Int(nullable: false));
        }
    }
}
