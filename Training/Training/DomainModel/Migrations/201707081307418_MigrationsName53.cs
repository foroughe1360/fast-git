namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName53 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supervisors", "DepartmentId", c => c.Int(nullable: false));
            DropColumn("dbo.Supervisors", "UnitSCenterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supervisors", "UnitSCenterId", c => c.Int(nullable: false));
            DropColumn("dbo.Supervisors", "DepartmentId");
        }
    }
}
