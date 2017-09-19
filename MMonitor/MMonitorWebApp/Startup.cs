using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MMonitorWebApp.Startup))]
namespace MMonitorWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
