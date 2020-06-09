using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using ResumeService.Areas.Identity.Data;

namespace ResumeService.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;

        public ConfirmEmailModel(UserManager<ResumeServiceUsers> userManager)
        {
            UserManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToPage("/Index");


            ResumeServiceUsers User = await UserManager.FindByIdAsync(userId);

            if (User == null)
                return NotFound($"Unable to load user with ID '{userId}'.");

            var result = await UserManager.ConfirmEmailAsync(User,
                Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code)));

            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return Page();
        }
    }
}
