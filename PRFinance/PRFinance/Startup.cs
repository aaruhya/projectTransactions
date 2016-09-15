using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRFinance.Startup))]
namespace PRFinance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
