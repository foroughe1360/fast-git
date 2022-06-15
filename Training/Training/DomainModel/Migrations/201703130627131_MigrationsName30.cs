namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingPageFiles", "TrainingPageFileDesc", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingPageFiles", "TrainingPageFileDesc");
        }
    }
}
