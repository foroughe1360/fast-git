namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingCalendars", "TrainingCalendarDay", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingCalendars", "TrainingCalendarDay");
        }
    }
}
