namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName45 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventoryjobs", "AsJobs2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Inventoryjobs", "Experience", c => c.String(maxLength: 1100));
            AlterColumn("dbo.Inventoryjobs", "Responsibilities", c => c.String(maxLength: 1100));
            AlterColumn("dbo.Inventoryjobs", "Qualified", c => c.String(maxLength: 1100));
            AlterColumn("dbo.Inventoryjobs", "OtherTraining", c => c.String(maxLength: 1100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventoryjobs", "OtherTraining", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Inventoryjobs", "Qualified", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Inventoryjobs", "Responsibilities", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Inventoryjobs", "Experience", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Inventoryjobs", "AsJobs2", c => c.String(maxLength: 50));
        }
    }
}
