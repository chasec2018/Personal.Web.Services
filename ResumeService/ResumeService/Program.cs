
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;


namespace ResumeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(Configuration =>
                {
                    IConfigurationRoot ConfigurationsRoots = Configuration.Build();

                    Configuration.AddAzureKeyVault(
                        $"https://{ConfigurationsRoots["AzureKeyVault:AzureVaultName"]}.vault.azure.net/",
                        ConfigurationsRoots["AzureKeyVault:AzureApplicationID"],
                        ConfigurationsRoots["AzureKeyVault:AzureApplicationSecret"]);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
