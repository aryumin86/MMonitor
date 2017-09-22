namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_index_for_url_hash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheSources", "UrlHash", c => c.String());
            DropColumn("dbo.TheSources", "ShortUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TheSources", "ShortUrl", c => c.String());
            DropColumn("dbo.TheSources", "UrlHash");
        }
    }
}
