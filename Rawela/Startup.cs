using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rawela.Startup))]
namespace Rawela
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
