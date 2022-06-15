namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName52 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        SupervisorId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        UnitSCenterId = c.Int(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupervisorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Supervisors");
        }
    }
}
