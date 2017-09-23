namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_some_fields_to_source : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheSources", "LastTimeAutamaticallEncodingUpdateTry", c => c.DateTime());
            AddColumn("dbo.TheSources", "AutomaticalEncodingUpdateWasSuccess", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheSources", "AutomaticalEncodingUpdateWasSuccess");
            DropColumn("dbo.TheSources", "LastTimeAutamaticallEncodingUpdateTry");
        }
    }
}
