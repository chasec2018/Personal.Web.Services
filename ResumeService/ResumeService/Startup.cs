using System.Text.Json;
using ResumeService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ResumeService.Areas.Identity;
using ResumeService.Areas.Identity.Data;

namespace ResumeService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddTransient<EmailHandler>();
            services.AddTransient<JsonDataHandler>();
            services.AddTransient<KeyVaultHandler>();
            services.AddControllers();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
           else
                app.UseExceptionHandler("/Error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            // Build Migration at runtime : Environment (Production/Development) will dictate Connection String
            using (IServiceScope Scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // Step 01 : Create Database (If it does not already exist)
                Scope.ServiceProvider.GetService<ResumeServiceContext>().Database.Migrate();

                // Step 02 : Seed Database with Default Roles and Admin User
                await Scope.ServiceProvider.GetService<IdentityDbSeeder>().SeedDatabaseAsync();
            }
        }
    }
}
