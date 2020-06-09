﻿using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ResumeService.Areas.Identity.Data;
using ResumeService.Services;
using ResumeService.Areas.Identity.Models;

namespace ResumeService.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly RoleManager<ResumeServiceRoles> RoleManager;
        private readonly SignInManager<ResumeServiceUsers> SignInManager;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly ILogger<RegisterModel> Logger;
        private readonly IdentitySeeds Seeder;

        public RegisterModel(RoleManager<ResumeServiceRoles> roleManager, UserManager<ResumeServiceUsers> userManager, SignInManager<ResumeServiceUsers> signInManager, ILogger<RegisterModel> logger, IdentitySeeds seeder)
        {
            RoleManager = roleManager;
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
            Seeder = seeder;
        }

        [BindProperty]
        public InputRegisterModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            //ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                await Seeder.SeedDatabase();

                ResumeServiceUsers User = new ResumeServiceUsers()
                { 
                    UserName = Input.Username,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    Email = Input.Email,
                    Birthday = Input.Birthdate,
                    Company = Input.Company,
                    JobTitle = Input.JobTitle
                };

                IdentityResult UserResult = await UserManager.CreateAsync(User, Input.Password);
                IdentityResult RoleResult = await UserManager.AddToRoleAsync(User, "Guest");

                if (UserResult.Succeeded && RoleResult.Succeeded)
                {
                    Logger.LogInformation("User created a new account with password.");

                    string Code = WebEncoders.Base64UrlEncode(
                        Encoding.UTF8.GetBytes(
                            await UserManager.GenerateEmailConfirmationTokenAsync(User)));

                    string CallbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new 
                        { 
                            area = "Identity", 
                            userId = User.Id, 
                            code = Code, 
                            returnUrl = returnUrl 
                        },
                        protocol: Request.Scheme);


                    if (UserManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage(
                            "RegisterConfirmation", 
                            new 
                            { 
                                email = Input.Email, 
                                subject = "Chase's Web App : Email Confirmation",
                                htmlMessage = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(CallbackUrl)}'>clicking here</a>.",
                                returnUrl = returnUrl 
                            });
                    }
                    else
                    {
                        await SignInManager.SignInAsync(User, isPersistent: true);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (IdentityError Error in UserResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, Error.Description);
                }
            }
            return Page();
        }
    }
}
