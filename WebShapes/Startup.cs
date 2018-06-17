using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShapes.Startup))]
namespace WebShapes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
