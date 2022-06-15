namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationHardwareInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HardwareInformations",
                c => new
                    {
                        HardwareInformationId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        EmployemeId = c.Int(nullable: false),
                        HardwareEquipmentId = c.Int(nullable: false),
                        NetworkID = c.String(),
                        NetworkIP = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        Descriptions = c.String(),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HardwareInformationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HardwareInformations");
        }
    }
}
