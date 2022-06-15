namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName51 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DesignTrainingCourses", "ListLearningAssistToolComment", c => c.String(maxLength: 1000));
            AddColumn("dbo.Inventoryjobs", "ListCommunityOrganizationComment", c => c.String(maxLength: 1000));
            AlterColumn("dbo.ListTrainingRequireds", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListTrainingRequireds", "Description", c => c.String(maxLength: 50));
            DropColumn("dbo.Inventoryjobs", "ListCommunityOrganizationComment");
            DropColumn("dbo.DesignTrainingCourses", "ListLearningAssistToolComment");
        }
    }
}
