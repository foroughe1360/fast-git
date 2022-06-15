namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration14000613 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingCalendars", "TableTypeTrainingCalendarDateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingCalendars", "TableTypeTrainingCalendarDateId");
        }
    }
}
