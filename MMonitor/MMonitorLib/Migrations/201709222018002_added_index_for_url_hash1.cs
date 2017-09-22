namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_index_for_url_hash1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TheSources", "UrlHash", c => c.String(maxLength: 32));
            CreateIndex("dbo.TheSources", "UrlHash");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TheSources", new[] { "UrlHash" });
            AlterColumn("dbo.TheSources", "UrlHash", c => c.String());
        }
    }
}
