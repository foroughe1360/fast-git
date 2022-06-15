namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName970206 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferTrainingForEmployeeDates", "MyProperty", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferTrainingForEmployeeDates", "MyProperty");
        }
    }
}
