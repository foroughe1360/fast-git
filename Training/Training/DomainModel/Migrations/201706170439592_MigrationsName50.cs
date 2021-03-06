namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName50 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventoryjobs", "OtherAbilityRequiredJob", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventoryjobs", "OtherAbilityRequiredJob");
        }
    }
}
