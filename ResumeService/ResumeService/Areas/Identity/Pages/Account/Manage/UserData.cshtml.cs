using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeService.Areas.Identity.EntityModels;

namespace ResumeService.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class UserDataModel : PageModel
    {
        private readonly SignInManager<ResumeServiceUsers> SignInManager;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly ILogger<UserDataModel> Logger;

        public UserDataModel(SignInManager<ResumeServiceUsers> signInManager, UserManager<ResumeServiceUsers> userManager,ILogger<UserDataModel> logger)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            Logger = logger;
        }

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        public async Task<IActionResult> OnGet()
        {
            var user = await UserManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");
            }

            return Page();
        }


        public async Task<IActionResult> OnPostDeleteAccountAsync()
        {
            var user = await UserManager.GetUserAsync(User);

            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");


            if (!await UserManager.CheckPasswordAsync(user, Password))
            {
                ModelState.AddModelError(string.Empty, "Incorrect password.");
                return Page();
            }

            var result = await UserManager.DeleteAsync(user);
            var userId = await UserManager.GetUserIdAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            await SignInManager.SignOutAsync();

            Logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
    }
}