namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Country_Property_To_Source_And_Its_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counrties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TheSources", "Country_Id", c => c.Int());
            CreateIndex("dbo.TheSources", "Country_Id");
            AddForeignKey("dbo.TheSources", "Country_Id", "dbo.Counrties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TheSources", "Country_Id", "dbo.Counrties");
            DropIndex("dbo.TheSources", new[] { "Country_Id" });
            DropColumn("dbo.TheSources", "Country_Id");
            DropTable("dbo.Counrties");
        }
    }
}
