namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employemes", name: "EmployemeJobId", newName: "EmployemeId");
            CreateTable(
                "dbo.AttendanceDates",
                c => new
                    {
                        AttendanceDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        DesignTrainingCourseId = c.Int(nullable: false),
                        AttendanceAbsenceDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceDateId);
            
            AddColumn("dbo.Attendances", "TypeAttendanceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employemes", "IDNumber", c => c.String(maxLength: 50));
            DropColumn("dbo.Attendances", "AttendanceDate");
            DropColumn("dbo.Attendances", "IsAttendance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "IsAttendance", c => c.Boolean(nullable: false));
            AddColumn("dbo.Attendances", "AttendanceDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employemes", "IDNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Attendances", "TypeAttendanceId");
            DropTable("dbo.AttendanceDates");
            RenameColumn(table: "dbo.Employemes", name: "EmployemeId", newName: "EmployemeJobId");
        }
    }
}
