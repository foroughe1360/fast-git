namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogErrors", "OperationTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.LogErrors", "AccessTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogErrors", "AccessTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.LogErrors", "OperationTypeId");
        }
    }
}
