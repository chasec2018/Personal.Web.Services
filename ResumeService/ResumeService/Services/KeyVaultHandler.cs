
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace ResumeService.Services
{
    public class KeyVaultHandler
    {
        private readonly VaultSecrets secrets;

        public KeyVaultHandler(IWebHostEnvironment env, IConfiguration configurations)
        {
            if (env.IsProduction())
                secrets = JsonSerializer.Deserialize<VaultSecrets>(configurations["ResumeServiceProduction"]);
            else
                secrets = JsonSerializer.Deserialize<VaultSecrets>(configurations["ResumeServiceDevelopment"]);
        }

        public VaultSecrets Secrets
        {
            get
            {
                return secrets;
            }
        }

        public class VaultSecrets
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
