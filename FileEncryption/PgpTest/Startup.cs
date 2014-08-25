using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PgpTest.Startup))]
namespace PgpTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
