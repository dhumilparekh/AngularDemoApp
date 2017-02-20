using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneDemoApp.Startup))]
namespace GeneDemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
