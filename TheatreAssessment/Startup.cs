using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheatreAssessment.Startup))]
namespace TheatreAssessment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
