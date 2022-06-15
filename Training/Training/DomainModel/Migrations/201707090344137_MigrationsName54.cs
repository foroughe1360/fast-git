namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName54 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlacementTabJobTrainings", "CorporateResponsibility", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlacementTabJobTrainings", "CorporateResponsibility");
        }
    }
}
