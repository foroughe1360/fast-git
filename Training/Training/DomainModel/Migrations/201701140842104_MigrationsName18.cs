namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesignTrainingCourseDates",
                c => new
                    {
                        DesignTrainingCourseDateId = c.Int(nullable: false, identity: true),
                        GUID = c.String(maxLength: 50),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeLastModified = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                        DTCDate = c.DateTime(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DesignTrainingCourseDateId);
            
            AddColumn("dbo.DesignTrainingCourses", "DesignTrainingCourseDateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesignTrainingCourses", "DesignTrainingCourseDateId");
            DropTable("dbo.DesignTrainingCourseDates");
        }
    }
}
