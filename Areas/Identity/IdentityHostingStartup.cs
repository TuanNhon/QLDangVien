using System;
using dangVienManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(dangVienManagement.Areas.Identity.IdentityHostingStartup))]
namespace dangVienManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<dangVienManagementIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("dangVienManagementIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<dangVienManagementIdentityDbContext>();
            });
        }
    }
}
