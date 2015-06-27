using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoWeb.Startup))]
namespace ProjetoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
