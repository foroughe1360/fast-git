namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName35 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogErrors", "ErrorMessage", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogErrors", "ErrorMessage", c => c.String(maxLength: 50));
        }
    }
}
