namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName13980622 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SetDateForRepors", "DateOfRegistrar", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SetDateForRepors", "DateOfRegistrar");
        }
    }
}
