using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMvcSite.Domain.Startup))]
namespace MyMvcSite.Domain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
