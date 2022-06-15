namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employemes", "NationalCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employemes", "NationalCode");
        }
    }
}
