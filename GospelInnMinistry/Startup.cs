using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GospelInnMinistry.Startup))]
namespace GospelInnMinistry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
