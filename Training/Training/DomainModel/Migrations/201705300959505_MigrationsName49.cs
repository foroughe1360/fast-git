namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName49 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventoryjobs", "ListResponsibilitiePowerId", c => c.Int(nullable: false));
            DropColumn("dbo.Inventoryjobs", "Responsibilities");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventoryjobs", "Responsibilities", c => c.String(maxLength: 1000));
            DropColumn("dbo.Inventoryjobs", "ListResponsibilitiePowerId");
        }
    }
}
