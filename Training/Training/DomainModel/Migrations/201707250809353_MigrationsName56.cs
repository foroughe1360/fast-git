namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName56 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semats",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codp = c.String(maxLength: 50),
                        semat = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Semats");
        }
    }
}
