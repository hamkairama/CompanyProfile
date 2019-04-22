using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyProject.Startup))]
namespace CompanyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
