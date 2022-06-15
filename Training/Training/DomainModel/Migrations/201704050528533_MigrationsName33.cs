namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationLogs", "OperationTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.OperationLogs", "RecordId", c => c.Int(nullable: false));
            DropColumn("dbo.OperationLogs", "AccessTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OperationLogs", "AccessTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.OperationLogs", "RecordId");
            DropColumn("dbo.OperationLogs", "OperationTypeId");
        }
    }
}
