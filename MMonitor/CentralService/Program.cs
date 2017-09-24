using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CentralService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandeledExeptionHandler);

            if (Environment.UserInteractive)
            {
                SourcesProcessingService srv = new SourcesProcessingService();
                srv.RunToDebug(args);
                Console.ReadLine();
            }
            else
            {
                ServicesToRun = new ServiceBase[]
                {
                    new SourcesProcessingService()
                };
                ServiceBase.Run(ServicesToRun);
            }

            ServicesToRun = new ServiceBase[]
            {
                new SourcesProcessingService()
            };
            ServiceBase.Run(ServicesToRun);            
        }

        /// <summary>
        /// Unhandled exception handler.
        /// </summary>
        static void UnhandeledExeptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            SourcesProcessingService.log.Fatal("Service stopped\n" + ex);
        }
    }
}
