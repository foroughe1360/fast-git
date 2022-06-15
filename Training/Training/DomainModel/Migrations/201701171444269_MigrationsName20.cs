namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListCommunityOrganizations", "CommunicationOrganizationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListCommunityOrganizations", "CommunicationOrganizationId");
        }
    }
}
