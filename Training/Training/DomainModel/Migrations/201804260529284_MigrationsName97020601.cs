namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName97020601 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OfferTrainingForEmployeeDates", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OfferTrainingForEmployeeDates", "MyProperty", c => c.String(maxLength: 100));
        }
    }
}
