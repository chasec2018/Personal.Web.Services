using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using ResumeService.Areas.Identity.Data;
using ResumeService.Services;
using System;

namespace ResumeService.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly IEmailSender EmailSender;

        public RegisterConfirmationModel(UserManager<ResumeServiceUsers> userManager, EmailHandler emailSender)
        {
            UserManager = userManager;
            EmailSender = emailSender;
        }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool ErrorOccurred { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(string email, string subject, string htmlMessage, string returnUrl = null)
        {
            try
            {
                if (email == null)
                    return RedirectToPage("/Index");

                if (await UserManager.FindByEmailAsync(email) == null)
                    return NotFound($"Unable to load user with email '{email}'.");

                Email = email;

                await EmailSender.SendEmailAsync(email, subject, htmlMessage);
            }
            catch(Exception exception)
            {
                ErrorOccurred = true;

                
                if(email != null)
                {
                    ResumeServiceUsers User = await UserManager.FindByEmailAsync(email);
                    await UserManager.DeleteAsync(User);
                }
            }
           

            return Page();
        }
    }
}
