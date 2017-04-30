using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(SharpForum.Application.Startup))]
namespace SharpForum.Application
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}