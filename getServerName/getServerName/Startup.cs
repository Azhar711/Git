using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(getServerName.Startup))]
namespace getServerName
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
