using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Storm.InterviewTest.Hearthstone.Startup))]
namespace Storm.InterviewTest.Hearthstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
