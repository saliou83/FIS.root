using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fis.Portail.Startup))]
namespace Fis.Portail
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
