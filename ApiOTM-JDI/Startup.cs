using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ApiOTM.Startup))]

namespace ApiOTM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
