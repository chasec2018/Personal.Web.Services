using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeService.Areas.Identity.Data;
using ResumeService.Areas.Identity.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public InputProfileModel Input { get; set; }


        private async Task LoadAsync(ResumeServiceUsers user)
        {

            var userName = await UserManager.GetUserNameAsync(user);
            var phoneNumber = await UserManager.GetPhoneNumberAsync(user);


            ResumeServiceUsers User = await UserManager.FindByNameAsync(await UserManager.GetUserNameAsync(user));

            Username = User.UserName;

            Input = new InputProfileModel
            {
                Username = User.UserName,
                FirstName = User.FirstName,
                LastName = User.LastName,
                PhoneNumber =  User.PhoneNumber,
                Email = User.Email,
                Birthdate = User.Birthday,
                Company = User.Company,
                JobTitle = User.JobTitle
            };
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

            user.UserName = Input.Username;
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.Birthday = Input.Birthdate;
            user.PhoneNumber = Input.PhoneNumber;
            user.Company = Input.Company;
            user.JobTitle = Input.JobTitle;

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
