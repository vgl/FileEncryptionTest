using FileEncryption.WebApp;

using Microsoft.Owin;

using Owin;

//[assembly: OwinStartup(typeof(Startup))]
namespace FileEncryption.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
