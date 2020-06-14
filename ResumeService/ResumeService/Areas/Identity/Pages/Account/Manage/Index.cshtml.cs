
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeService.Areas.Identity.InputModels;
using ResumeService.Areas.Identity.EntityModels;
using System.ComponentModel.DataAnnotations;
using System;

namespace ResumeService.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly SignInManager<ResumeServiceUsers> SignInManager;

        public IndexModel(UserManager<ResumeServiceUsers> userManager, SignInManager<ResumeServiceUsers> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PhoneNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime Birthdate { get; set; }

        [EmailAddress]
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Company { get; set; }

        [BindProperty(SupportsGet = true)]
        public string JobTitle { get; set; }


        private async Task LoadAsync(ResumeServiceUsers user)
        {
            ResumeServiceUsers User = await UserManager.FindByNameAsync(await UserManager.GetUserNameAsync(user));

            Username = User.UserName;
            FirstName = User.FirstName;
            LastName = User.LastName;
            PhoneNumber = User.PhoneNumber;
            Email = User.Email;
            Birthdate = User.Birthday;
            Company = User.Company;
            JobTitle = User.JobTitle;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ResumeServiceUsers user = await UserManager.GetUserAsync(User);

            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");

            await LoadAsync(user);
            return Page();
        }



        public async Task<IActionResult> OnPostAsync()
        {
            ResumeServiceUsers user = await UserManager.GetUserAsync(User);

            if (user == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");

            
            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.UserName = Username;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Birthday = Birthdate;
            user.PhoneNumber = PhoneNumber;
            user.Company = Company;
            user.JobTitle = JobTitle;

            IdentityResult Result = await UserManager.UpdateAsync(user);

            if (Result.Succeeded)
            {
                await SignInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
                return RedirectToPage();
            }
            else
            {

                foreach(var Error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, Error.Description);
                }
                return Page();
            }
        }
    }
}
