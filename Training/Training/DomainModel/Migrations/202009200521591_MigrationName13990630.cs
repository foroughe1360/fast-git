namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName13990630 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationEmployemes", "ActiveTypeOfUniversity", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EducationEmployemes", "ActiveTypeOfUniversity");
        }
    }
}
