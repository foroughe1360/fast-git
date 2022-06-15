namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations14000526 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HardwareNames",
                c => new
                    {
                        HardwareNameId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        HardwareTitle = c.String(),
                        State = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HardwareNameId);
            
            AddColumn("dbo.HardwareEquipments", "EquipmentNameId", c => c.Int(nullable: false));
            DropColumn("dbo.HardwareEquipments", "EquipmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HardwareEquipments", "EquipmentName", c => c.String());
            DropColumn("dbo.HardwareEquipments", "EquipmentNameId");
            DropTable("dbo.HardwareNames");
        }
    }
}
