using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StorForStudentsWebApp.Startup))]
namespace StorForStudentsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
