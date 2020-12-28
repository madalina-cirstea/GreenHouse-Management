using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenHouse_Management.Startup))]
namespace GreenHouse_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
