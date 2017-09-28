namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheSources", "LastTimeAutomaticalRulesUpdateEffort", c => c.DateTime());
            AddColumn("dbo.TheSources", "LastTimeAutomaticalEncodingUpdateEffort", c => c.DateTime());
            DropColumn("dbo.TheSources", "LastTimeAutamaticallRulesUpdateTry");
            DropColumn("dbo.TheSources", "LastTimeAutamaticallEncodingUpdateTry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TheSources", "LastTimeAutamaticallEncodingUpdateTry", c => c.DateTime());
            AddColumn("dbo.TheSources", "LastTimeAutamaticallRulesUpdateTry", c => c.DateTime());
            DropColumn("dbo.TheSources", "LastTimeAutomaticalEncodingUpdateEffort");
            DropColumn("dbo.TheSources", "LastTimeAutomaticalRulesUpdateEffort");
        }
    }
}
