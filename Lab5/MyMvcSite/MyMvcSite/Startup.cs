using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMvcSite.Startup))]
namespace MyMvcSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
