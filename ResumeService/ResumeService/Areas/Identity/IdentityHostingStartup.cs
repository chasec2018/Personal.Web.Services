﻿using System;
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
                    if (Context.HostingEnvironment.IsProduction())
                        Secrets = JsonSerializer.Deserialize<VaultSecrets>(Context.Configuration["ResumeServiceProduction"]);
                    else
                        Secrets = JsonSerializer.Deserialize<VaultSecrets>(Context.Configuration["ResumeServiceDevelopment"]);

                    options.UseSqlServer(Secrets.ConnectionString);
                });

                services.AddIdentity<ResumeServiceUsers, ResumeServiceRoles>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.User.RequireUniqueEmail = true;
                })
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<ResumeServiceContext>();

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
