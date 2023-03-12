using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenKhacLoc_2080600451.Startup))]
namespace NguyenKhacLoc_2080600451
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
