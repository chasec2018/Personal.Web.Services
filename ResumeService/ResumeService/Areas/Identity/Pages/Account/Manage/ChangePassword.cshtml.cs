
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResumeService.Areas.Identity.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ResumeService.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly SignInManager<ResumeServiceUsers> SignManager;
        private readonly ILogger<ChangePasswordModel> Logger;

        public ChangePasswordModel(UserManager<ResumeServiceUsers> userManager, SignInManager<ResumeServiceUsers> signInManager, ILogger<ChangePasswordModel> logger)
        {
            UserManager = userManager;
            SignManager = signInManager;
            Logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            ResumeServiceUsers user = await UserManager.GetUserAsync(User);

            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if(NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The Passwords do not match");
                return Page();
            }

            ResumeServiceUsers user = await UserManager.GetUserAsync(User);

            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");
            

            IdentityResult ChangePasswordResult = await UserManager.ChangePasswordAsync(user, OldPassword, NewPassword);

            if (!ChangePasswordResult.Succeeded)
            {
                foreach (var error in ChangePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await SignManager.RefreshSignInAsync(user);
            Logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToPage();
        }
    }
}
