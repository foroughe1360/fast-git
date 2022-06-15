namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName990604 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignatureResponsibilities", "EmployemeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignatureResponsibilities", "EmployemeId");
        }
    }
}
