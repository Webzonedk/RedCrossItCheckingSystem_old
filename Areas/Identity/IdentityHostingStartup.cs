using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedCrossItCheckingSystem.Areas.Identity.Data;
using RedCrossItCheckingSystem.Data;

[assembly: HostingStartup(typeof(RedCrossItCheckingSystem.Areas.Identity.IdentityHostingStartup))]
namespace RedCrossItCheckingSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RedCrossItCheckingSystem.Data.RedCrossItCheckingSystemDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RedCrossItCheckingSystemDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<RedCrossItCheckingSystem.Data.RedCrossItCheckingSystemDbContext>();
            });
        }
    }
}