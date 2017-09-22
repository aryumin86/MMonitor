namespace MMonitorLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clusters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        TheSourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TheSources", t => t.TheSourceId, cascadeDelete: true)
                .Index(t => t.TheSourceId);
            
            CreateTable(
                "dbo.TheSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        ShortUrl = c.String(),
                        Description = c.String(),
                        TheSourceType = c.Int(nullable: false),
                        MediaAudienceType = c.Int(nullable: false),
                        Enc = c.String(),
                        Lang = c.Int(nullable: false),
                        UserAgent = c.String(),
                        RequestTimeOut = c.Int(nullable: false),
                        LastTimeAutamaticallRulesUpdatetry = c.DateTime(),
                        AutomaticalRulesUpdateWasSuccess = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageParsingRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentXPath = c.String(),
                        PubDateXPath = c.String(),
                        AuthorXPath = c.String(),
                        RuleCreationDate = c.DateTime(nullable: false),
                        UrlRegex = c.String(),
                        TitleRegex = c.String(),
                        AuthorId = c.String(),
                        AverageRuleEvaluation = c.Double(),
                        RejectedByUser = c.Boolean(),
                        TheSource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TheSources", t => t.TheSource_Id)
                .Index(t => t.TheSource_Id);
            
            CreateTable(
                "dbo.RssPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        TheSourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TheSources", t => t.TheSourceId, cascadeDelete: true)
                .Index(t => t.TheSourceId);
            
            CreateTable(
                "dbo.AbstractPublications",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        UrlShorted = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        PubDate = c.DateTime(nullable: false),
                        SourceId = c.Int(nullable: false),
                        UrlHash = c.String(),
                        TitleHash = c.String(),
                        ContentHash = c.String(),
                        FromRSS = c.Boolean(nullable: false),
                        ClusterId = c.Int(),
                        MainArticle_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clusters", t => t.ClusterId)
                .ForeignKey("dbo.AbstractPublications", t => t.MainArticle_Id)
                .ForeignKey("dbo.TheSources", t => t.SourceId, cascadeDelete: true)
                .Index(t => t.SourceId)
                .Index(t => t.ClusterId)
                .Index(t => t.MainArticle_Id);
            
            CreateTable(
                "dbo.TheComments",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        AbstractPublicationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbstractPublications", t => t.Id)
                .ForeignKey("dbo.AbstractPublications", t => t.AbstractPublicationId)
                .Index(t => t.Id)
                .Index(t => t.AbstractPublicationId);
            
            CreateTable(
                "dbo.ThePublications",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbstractPublications", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThePublications", "Id", "dbo.AbstractPublications");
            DropForeignKey("dbo.TheComments", "AbstractPublicationId", "dbo.AbstractPublications");
            DropForeignKey("dbo.TheComments", "Id", "dbo.AbstractPublications");
            DropForeignKey("dbo.AbstractPublications", "SourceId", "dbo.TheSources");
            DropForeignKey("dbo.AbstractPublications", "MainArticle_Id", "dbo.AbstractPublications");
            DropForeignKey("dbo.AbstractPublications", "ClusterId", "dbo.Clusters");
            DropForeignKey("dbo.RssPages", "TheSourceId", "dbo.TheSources");
            DropForeignKey("dbo.PageParsingRules", "TheSource_Id", "dbo.TheSources");
            DropForeignKey("dbo.NewsPages", "TheSourceId", "dbo.TheSources");
            DropIndex("dbo.ThePublications", new[] { "Id" });
            DropIndex("dbo.TheComments", new[] { "AbstractPublicationId" });
            DropIndex("dbo.TheComments", new[] { "Id" });
            DropIndex("dbo.AbstractPublications", new[] { "MainArticle_Id" });
            DropIndex("dbo.AbstractPublications", new[] { "ClusterId" });
            DropIndex("dbo.AbstractPublications", new[] { "SourceId" });
            DropIndex("dbo.RssPages", new[] { "TheSourceId" });
            DropIndex("dbo.PageParsingRules", new[] { "TheSource_Id" });
            DropIndex("dbo.NewsPages", new[] { "TheSourceId" });
            DropTable("dbo.ThePublications");
            DropTable("dbo.TheComments");
            DropTable("dbo.AbstractPublications");
            DropTable("dbo.RssPages");
            DropTable("dbo.PageParsingRules");
            DropTable("dbo.TheSources");
            DropTable("dbo.NewsPages");
            DropTable("dbo.Clusters");
        }
    }
}
