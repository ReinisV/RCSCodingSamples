namespace CatDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CatProfiles", "CatDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CatProfiles", "CatDescription");
        }
    }
}
