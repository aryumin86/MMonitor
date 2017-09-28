using CentralServiceLib.Helpers;
using MMonitorLib;
using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentralService
{
    partial class SourcesProcessingService : ServiceBase
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        int numOfSourcesForParallerlProcessing =
            int.Parse(ConfigurationManager.AppSettings["numOfSourcesForParallerlProcessing"]);

        private List<AbstractHelper> helpers = new List<AbstractHelper>()
        {
            new EncodingIdentifier(),
            new SourceLanguageIdentifier(),
            new ParseRulesIdentifier(),
            new RSSPagesIdentifier()
        };

        public SourcesProcessingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log.Info("Service started");
            Thread t = new Thread(new ThreadStart(StartProcessing));
            t.Start();

            Console.ReadLine();
        }

        protected override void OnStop()
        {
            log.Info("Service stopped");
        }

        public void RunToDebug(string[] args)
        {
            OnStart(args);
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Start main loop of processing the sources.
        /// </summary>
        private void StartProcessing()
        {
            while (true)
            {
                try
                {
                    using (var db = new MMonitorContext())
                    {
                        var sources = db.TheSources
                            .Where(s =>
                            s.Enc == null &&
                            s.AutomaticalEncodingUpdateWasSuccess == null)
                            .Take(numOfSourcesForParallerlProcessing);

                        if(sources.Count() == 0)
                        {
                            Thread.Sleep(1000 * 60 * 10);
                            continue;
                        }

                        log.Info($"{sources.Count()} sources were taken for processing");

                        Parallel.ForEach(sources, (s) =>
                        {
                            log.Info($"Starting processing of source {s.Url}");
                            Process(s);
                            log.Info($"Ended processing of source {s.Url}");
                        });

                        log.Info("Sources processing completed");
                        db.SaveChanges();
                        log.Info("Sources updated in db");
                    }
                }
                catch(Exception ex)
                {
                    log.Error("Error with processing sources", ex);
                    Thread.Sleep(5000);
                }             
            }
        }

        /// <summary>
        /// Process of the source - identifying language, encoding, title and so on.
        /// </summary>
        /// <param name="source"></param>
        private void Process(TheSource source)
        {
            foreach (var helper in helpers)
                helper.Identify(ref source);
        }
    }
}
