using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatDatingSite.Startup))]
namespace CatDatingSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
