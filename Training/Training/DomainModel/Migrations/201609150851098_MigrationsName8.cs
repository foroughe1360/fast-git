namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationEmployemes", "LastEducationalCertificate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EducationEmployemes", "LastEducationalCertificate");
        }
    }
}
