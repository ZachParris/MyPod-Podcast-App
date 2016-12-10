using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPod.Startup))]
namespace MyPod
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
