using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharpForum.Application.Startup))]
namespace SharpForum.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
