namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsHardwareEquipment : DbMigration
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
                        EquipmentName = c.String(),
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
