using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib
{
    public class MMonitorContext : DbContext
    {
        public MMonitorContext() : base("MMonitorConnection") { }

        public DbSet<NewsPage> NewsPages { get; set; }
        public DbSet<PageParsingRule> PageParsingRules { get; set; }
        public DbSet<RssPage> RssPages { get; set; }
        public DbSet<TheComment> TheComments { get; set; }
        public DbSet<ThePublication> ThePublications { get; set; }
        public DbSet<TheSource> TheSources { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
