namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_index_for_url_hash2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheSources", "IsApproved", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheSources", "IsApproved");
        }
    }
}
