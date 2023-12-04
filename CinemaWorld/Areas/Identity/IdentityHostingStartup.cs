using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CinemaWorld.Areas.Identity.IdentityHostingStartup))]

namespace CinemaWorld.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            _ = builder.ConfigureServices((context, services) =>
              {
              });
        }
    }
}
