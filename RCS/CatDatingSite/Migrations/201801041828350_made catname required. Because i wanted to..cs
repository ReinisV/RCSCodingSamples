namespace CatDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madecatnamerequiredBecauseiwantedto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CatProfiles", "CatName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CatProfiles", "CatName", c => c.String());
        }
    }
}
