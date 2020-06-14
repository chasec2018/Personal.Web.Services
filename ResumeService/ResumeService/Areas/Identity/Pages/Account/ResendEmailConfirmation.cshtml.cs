using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using ResumeService.Areas.Identity.EntityModels;


namespace ResumeService.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly IEmailSender EmailSender;


        public ResendEmailConfirmationModel(UserManager<ResumeServiceUsers> userManager, IEmailSender emailSender)
        {
            UserManager = userManager;
            EmailSender = emailSender;
        }

        [Required]
        [EmailAddress]
        [BindProperty]
        public string Email { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            ResumeServiceUsers User = await UserManager.FindByEmailAsync(Email);

            if(User == null)
            {
                ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
                return Page();
            }

            if(await UserManager.IsEmailConfirmedAsync(User))
            {
                ModelState.AddModelError(string.Empty, "Verfication not Required");
                return Page();
            }



            string userId = await UserManager.GetUserIdAsync(User);
            string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(
                await UserManager.GenerateEmailConfirmationTokenAsync(User)));

            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);

            await EmailSender.SendEmailAsync(
                Email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
            return Page();
        }
    }
}
