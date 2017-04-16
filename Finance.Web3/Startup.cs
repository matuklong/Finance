using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Finance.Web3.Startup))]
namespace Finance.Web3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
