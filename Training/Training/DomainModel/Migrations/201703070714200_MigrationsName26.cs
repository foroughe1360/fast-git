namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SideSignatories", "TitleEN", c => c.String(maxLength: 50));
            AddColumn("dbo.SideSignatories", "SideSignatoryCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SideSignatories", "SideSignatoryCode");
            DropColumn("dbo.SideSignatories", "TitleEN");
        }
    }
}
