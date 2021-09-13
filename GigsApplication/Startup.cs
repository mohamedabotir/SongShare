using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigsApplication.Startup))]
namespace GigsApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
