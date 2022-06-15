namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinancialCommitment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinancialCommitments", "FinancialYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinancialCommitments", "FinancialYear");
        }
    }
}
