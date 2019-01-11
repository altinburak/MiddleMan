using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiddleMan.Startup))]
namespace MiddleMan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
