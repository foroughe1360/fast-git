namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName13990624 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationEmployemes", "TableTypeOfUniversityId", c => c.Int(nullable: false));
            AddColumn("dbo.EducationEmployemes", "NameOfUniversity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EducationEmployemes", "NameOfUniversity");
            DropColumn("dbo.EducationEmployemes", "TableTypeOfUniversityId");
        }
    }
}
