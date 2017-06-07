using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ser_Web_CRUD_02.Startup))]
namespace Ser_Web_CRUD_02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
