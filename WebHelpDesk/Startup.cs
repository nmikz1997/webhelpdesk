using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebHelpDesk.Startup))]
namespace WebHelpDesk
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
