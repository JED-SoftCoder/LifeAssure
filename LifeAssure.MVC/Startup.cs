using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeAssure.MVC.Startup))]
namespace LifeAssure.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
