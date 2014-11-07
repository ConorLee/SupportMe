using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupportMe.Startup))]
namespace SupportMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
