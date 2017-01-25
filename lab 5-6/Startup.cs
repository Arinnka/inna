using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab_5_6.Startup))]
namespace lab_5_6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
