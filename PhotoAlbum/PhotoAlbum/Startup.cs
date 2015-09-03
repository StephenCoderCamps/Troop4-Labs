using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoAlbum.Startup))]
namespace PhotoAlbum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
