using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ResumeService.Data;
using ResumeService.Services;
using ResumeService.Properties;
using ResumeService.Areas.Identity;
using ResumeService.Areas.Identity.Data;
using Microsoft.Extensions.Options;


[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace ResumeService.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => 
            {
                services.AddDbContext<ResumeServiceContext>(options =>
                {
                    options.UseSqlServer(Resources.SqlConnectionString);
                });

                services.AddIdentity<ResumeServiceUsers, ResumeServiceRoles>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<ResumeServiceContext>();

                services.AddTransient<IdentitySeeds>();
                services.AddTransient<IEmailSender, EmailHandler>();
            });
        }
    }
}
