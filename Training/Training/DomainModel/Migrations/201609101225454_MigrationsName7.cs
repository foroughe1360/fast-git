namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TableInterfaces", "TableName", c => c.String(maxLength: 500));
            AlterColumn("dbo.TableInterfaces", "TableNameFarsi", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TableInterfaces", "TableNameFarsi", c => c.String(maxLength: 50));
            AlterColumn("dbo.TableInterfaces", "TableName", c => c.String(maxLength: 50));
        }
    }
}
