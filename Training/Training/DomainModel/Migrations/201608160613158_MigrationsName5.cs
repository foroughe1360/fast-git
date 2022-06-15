namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "AttendanceDateId", c => c.Int(nullable: false));
            AlterColumn("dbo.TableInterfaces", "TableNameFarsi", c => c.String(maxLength: 50));
            AlterColumn("dbo.TrainingCourses", "CourseName", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingCourses", "CourseName", c => c.String(maxLength: 50));
            AlterColumn("dbo.TableInterfaces", "TableNameFarsi", c => c.String());
            DropColumn("dbo.Attendances", "AttendanceDateId");
        }
    }
}
