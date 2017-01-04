using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LunchIncentro.Startup))]
namespace LunchIncentro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
