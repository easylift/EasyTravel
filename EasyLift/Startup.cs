using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyLift.Startup))]
namespace EasyLift
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
