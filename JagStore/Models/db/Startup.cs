using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JagStore.Startup))]
namespace JagStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
