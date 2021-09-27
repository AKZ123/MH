using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MH.Web.Startup))]
namespace MH.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
