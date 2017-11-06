namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIgnorePropToTheSource : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheSources", "IgnoreForAutomaticHelpersWork", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheSources", "IgnoreForAutomaticHelpersWork");
        }
    }
}
