using System;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using ResumeService.Services;
using ResumeService.Areas.Identity;
using ResumeService.Areas.Identity.Data;
using ResumeService.Areas.Identity.EntityModels;


[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace ResumeService.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((Context, services) =>
            {
                VaultSecrets Secrets = null;

                services.AddDbContext<ResumeServiceContext>(options =>
                {
                    if (Context.HostingEnvironment.IsEnvironment("Local"))
                        Secrets = JsonSerializer.Deserialize<VaultSecrets>(Context.Configuration["ResumeServiceLocal"]);

                    if (Context.HostingEnvironment.IsProduction())
                        Secrets = JsonSerializer.Deserialize<VaultSecrets>(Context.Configuration["ResumeServiceProduction"]);

                    if (Context.HostingEnvironment.IsDevelopment())
                        Secrets = JsonSerializer.Deserialize<VaultSecrets>(Context.Configuration["ResumeServiceDevelopment"]);

                    options.UseSqlServer(Secrets.ConnectionString);
                });

                services.AddIdentity<ResumeServiceUsers, ResumeServiceRoles>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;

                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                })
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<ResumeServiceContext>();

                services.ConfigureApplicationCookie(options =>
                {
                    options.AccessDeniedPath = $"/Identity/Account/PageNotFound";
                });

                services.AddTransient<IdentityDbSeeder>();
                services.AddSingleton<IEmailSender, EmailHandler>();
            });
        }

        internal class VaultSecrets
        {
            public string SmtpDeliveryPassword { get; set; }
            public string SmtpDeliveryServer { get; set; }
            public string SmtpDeliveryUsername { get; set; }
            public string ConnectionString { get; set; }
            public string DefaultAdminUsername { get; set; }
            public string DefaultAdminPassword { get; set; }
            public string DefaultAdminEmail { get; set; }
        }
    }
}
