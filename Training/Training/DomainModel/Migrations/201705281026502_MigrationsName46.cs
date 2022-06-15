namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName46 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventoryjobs", "TheoreticalKnowledge", c => c.String(maxLength: 1100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventoryjobs", "TheoreticalKnowledge", c => c.String(maxLength: 1000));
        }
    }
}
