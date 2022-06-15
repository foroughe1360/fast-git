namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TableInterfaceValues", "TableInterfaceValueCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TableInterfaceValues", "TableInterfaceValueCode");
        }
    }
}
