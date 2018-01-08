namespace CatDatingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvalidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Title", c => c.String());
            AlterColumn("dbo.Blogs", "Email", c => c.String());
        }
    }
}
