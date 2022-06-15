namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventoryjobs", "PercentPhysicalActivity", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Inventoryjobs", "PercentMentalActivity", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventoryjobs", "PercentMentalActivity", c => c.Int(nullable: false));
            AlterColumn("dbo.Inventoryjobs", "PercentPhysicalActivity", c => c.Int(nullable: false));
        }
    }
}
