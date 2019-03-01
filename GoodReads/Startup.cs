using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoodReads.Startup))]
namespace GoodReads
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
