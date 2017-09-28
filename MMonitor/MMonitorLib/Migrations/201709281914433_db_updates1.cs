namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_updates1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheSources", "AverageNumOfPublicationsPerDay", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheSources", "AverageNumOfPublicationsPerDay");
        }
    }
}
