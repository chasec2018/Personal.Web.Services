using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResumeService.Areas.Identity.Data;

namespace ResumeService.Controllers
{
    [ApiController]
    [Route("api/account/{action}")]
    public class AccountController : ControllerBase
    {

        private readonly SignInManager<ResumeServiceUsers> SignInManager;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly ILogger<AccountController> Logger;

        public AccountController(SignInManager<ResumeServiceUsers> signInManager, UserManager<ResumeServiceUsers> userManager, ILogger<AccountController> logger)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            Logger = logger;
        }


        public ResumeServiceUsers CurrentUser { get; set; }

        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();


        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await SignInManager.SignOutAsync();

            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }


        [HttpGet]
        public async Task<IActionResult> DownloadAsync()
        {
            CurrentUser = await UserManager.GetUserAsync(User);

            if (CurrentUser == null)
                return NotFound($"Unable to load user with ID '{UserManager.GetUserId(User)}'.");

            Logger.LogInformation("User with ID '{UserId}' asked for their personal data.", UserManager.GetUserId(User));

            var DataProps = typeof(ResumeServiceUsers)
                .GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));

            foreach (PropertyInfo property in DataProps)
            {
                Data.Add(property.Name, property.GetValue(CurrentUser)?.ToString() ?? "null");
            }

            IList<UserLoginInfo> Logins = await UserManager.GetLoginsAsync(CurrentUser);

            foreach (UserLoginInfo login in Logins)
            {
                Data.Add($"{login.LoginProvider} external login provider key", login.ProviderKey);
            }

            Response.Headers.Add("Content-Disposition", "attachment; filename=UserData.json");
            return new FileContentResult(JsonSerializer.SerializeToUtf8Bytes(Data), "application/json");
        }
    }
}