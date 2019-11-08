using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FuelInformaton.Startup))]
namespace FuelInformaton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
