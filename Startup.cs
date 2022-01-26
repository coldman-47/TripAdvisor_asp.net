using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripAdvisory_.Startup))]
namespace TripAdvisory_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
