using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechTestMVC.Areas.Identity.Data;
using TechTestMVC.Models;

[assembly: HostingStartup(typeof(TechTestMVC.Areas.Identity.IdentityHostingStartup))]
namespace TechTestMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TechTestMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TechTestMVCContextConnection")));

                services.AddDefaultIdentity<TechTestMVCUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TechTestMVCContext>();
            });
        }
    }
}