using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using udlejningsboliger.Areas.Identity.Data;
using udlejningsboliger.Data;

[assembly: HostingStartup(typeof(udlejningsboliger.Areas.Identity.IdentityHostingStartup))]
namespace udlejningsboliger.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<udlejningsboligerDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("udlejningsboligerDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<udlejningsboligerDbContext>();
            });
        }
    }
}