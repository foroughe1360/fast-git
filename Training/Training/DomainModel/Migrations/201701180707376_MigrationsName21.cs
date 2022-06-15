namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinancialCommitments", "FromDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.FinancialCommitments", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinancialCommitments", "ToDate");
            DropColumn("dbo.FinancialCommitments", "FromDate");
        }
    }
}
