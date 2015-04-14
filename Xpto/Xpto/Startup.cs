using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Xpto.Startup))]
namespace Xpto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
