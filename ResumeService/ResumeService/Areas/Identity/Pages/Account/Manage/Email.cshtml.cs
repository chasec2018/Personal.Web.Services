
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Authorization;
using ResumeService.Areas.Identity.EntityModels;

namespace ResumeService.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly SignInManager<ResumeServiceUsers> SignInManager;
        private readonly IEmailSender _emailSender;

        public EmailModel(UserManager<ResumeServiceUsers> userManager, SignInManager<ResumeServiceUsers> signInManager, IEmailSender emailSender)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _emailSender = emailSender;
        }

        public bool IsError { get; set; } = false;

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [EmailAddress]
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsEmailConfirmed { get; set; }

        [EmailAddress]
        [BindProperty]
        public string NewEmail { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            ResumeServiceUsers user = await UserManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");


            Email = user.Email;
            IsEmailConfirmed = user.EmailConfirmed;
            NewEmail = user.Email;
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            ResumeServiceUsers user = await UserManager.GetUserAsync(User);

            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");

            if (!ModelState.IsValid)
            {
                string EMail = await UserManager.GetEmailAsync(user);
                Email = EMail;
                NewEmail = EMail;
                return Page();
            }

            Email = await UserManager.GetEmailAsync(user);

            // Check for Users with Pre-existing Email Addresses
            ResumeServiceUsers NewEmailExist = await UserManager.FindByEmailAsync(NewEmail);

            // Validate that no User was returned for New Email Address
            if (NewEmailExist != null)
            {
                ModelState.AddModelError(string.Empty, $"Email is already in use '{NewEmail}'");
                IsEmailConfirmed = true;
                return Page();
            }

            if (NewEmail != Email)
            {
                string UserId = await UserManager.GetUserIdAsync(user);
                string EmailToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(
                    await UserManager.GenerateChangeEmailTokenAsync(user, NewEmail)));

                string CallbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new 
                    { 
                        userId = UserId,
                        email = NewEmail, 
                        code = EmailToken
                    },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(
                    NewEmail,
                    "Chase's Web App : Email Confirmation",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(CallbackUrl)}'>clicking here</a>.");

                StatusMessage = "Confirmation link to change email sent. Please check your email.";
                return RedirectToPage();
            }

            StatusMessage = "Your email is unchanged.";
            return RedirectToPage();
        }
    }
}
