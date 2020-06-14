using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ResumeService.Areas.Identity.EntityModels;
using ResumeService.Services;

namespace ResumeService.Areas.Identity
{
    public sealed class IdentityDbSeeder
    {
        private readonly RoleManager<ResumeServiceRoles> RoleManager;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly KeyVaultHandler KeyVault;

        public IdentityDbSeeder(RoleManager<ResumeServiceRoles> roleManager, UserManager<ResumeServiceUsers> userManager, KeyVaultHandler keyVaultHandler)
        {
            RoleManager = roleManager;
            UserManager = userManager;
            KeyVault = keyVaultHandler;
        }

        private readonly string[] Roles =
        {
            "Guest;External Users ",
            "Administrator;Main account for maintenance and security"
        };


        public async Task SeedDatabaseAsync()
        {
            foreach(string Role in Roles)
            {
                ResumeServiceRoles NewRole = new ResumeServiceRoles()
                {
                    Name = Role.Split(';')[0],
                    Description = Role.Split(';')[1]
                };

                if (!await RoleManager.RoleExistsAsync(Role))
                {
                    IdentityResult Result = await RoleManager.CreateAsync(NewRole);
                }
            }

            var user = await UserManager.FindByEmailAsync(KeyVault.Secrets.DefaultAdminEmail);

            if(user == null)
            {
                ResumeServiceUsers NewUser = new ResumeServiceUsers()
                {
                    FirstName = "Administrator",
                    LastName = "",
                    PhoneNumber = "",
                    EmailConfirmed = true,
                    UserName = KeyVault.Secrets.DefaultAdminUsername,
                    Email = KeyVault.Secrets.DefaultAdminEmail,
                    Birthday = DateTime.Now.Date,
                    Company = "",
                    JobTitle = ""
                };

                await UserManager.CreateAsync(NewUser, KeyVault.Secrets.DefaultAdminPassword);
                await UserManager.AddToRoleAsync(NewUser, "Administrator");
            }
        }
    }
}
