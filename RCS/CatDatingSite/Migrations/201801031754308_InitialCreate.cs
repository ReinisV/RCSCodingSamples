namespace CatDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatProfiles",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                        CatAge = c.Int(nullable: false),
                        CatImage = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CatProfiles");
        }
    }
}
