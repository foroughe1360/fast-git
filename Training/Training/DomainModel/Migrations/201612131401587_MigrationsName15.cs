namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlacementTabJobTrainings", "SectionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlacementTabJobTrainings", "SectionId");
        }
    }
}
