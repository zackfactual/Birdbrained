using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Birdbrained.Startup))]
namespace Birdbrained
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
