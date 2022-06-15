namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName55 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supervisors", "PostTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supervisors", "PostTypeId");
        }
    }
}
