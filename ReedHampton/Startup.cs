using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReedHampton.Startup))]
namespace ReedHampton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
