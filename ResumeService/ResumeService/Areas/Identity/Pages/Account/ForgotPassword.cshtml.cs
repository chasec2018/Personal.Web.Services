﻿
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity.UI.Services;
using ResumeService.Areas.Identity.EntityModels;


namespace ResumeService.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly IEmailSender EmailSender;

        public ForgotPasswordModel(UserManager<ResumeServiceUsers> userManager, IEmailSender emailSender)
        {
            UserManager = userManager;
            EmailSender = emailSender;
        }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string  Email { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ResumeServiceUsers User = await UserManager.FindByEmailAsync(Email);

                if (User == null || !(await UserManager.IsEmailConfirmedAsync(User)))
                    return RedirectToPage("./ForgotPasswordConfirmation");

                string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(
                    await UserManager.GeneratePasswordResetTokenAsync(User)));


                string callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                await EmailSender.SendEmailAsync(
                    Email,
                    "Chase's Web Application : Pasword Reset",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
