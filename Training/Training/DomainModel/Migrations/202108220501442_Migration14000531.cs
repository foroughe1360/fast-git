namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration14000531 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HardwareEquipments",
                c => new
                {
                    HardwareEquipmentId = c.Int(nullable: false, identity: true),
                    GUID = c.String(maxLength: 50),
                    TimeCreated = c.DateTime(nullable: false),
                    TimeLastModified = c.DateTime(nullable: false),
                    EquipmentNameId = c.Int(),
                    EquipmentModel = c.String(),
                    PropertyNumber = c.String(),
                    State = c.Boolean(nullable: false),
                    Hidden = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.HardwareEquipmentId);

        }

        public override void Down()
        {
            DropTable("dbo.HardwareEquipments");
        }
    }
}
