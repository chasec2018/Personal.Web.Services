using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ResumeService.Properties;
using ResumeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResumeService.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using ResumeService.Areas.Identity.Data;

namespace ResumeService.Pages.Forms
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> Logger;
        private readonly EmailHandler Emailer;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly SignInManager<ResumeServiceUsers> SignInManager;

        public ContactModel(ILogger<ContactModel> _Logger, EmailHandler _EmailHandler, UserManager<ResumeServiceUsers> _UserManager, SignInManager<ResumeServiceUsers> _SignInManager)
        {
            Logger = _Logger;
            Emailer = _EmailHandler;
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }

        [BindProperty]
        public bool EmailSent { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public EmailModel Email { get; set; }

        public async Task OnGetAsync()
        {
            if (SignInManager.IsSignedIn(User))
            {
                ResumeServiceUsers user = await UserManager.GetUserAsync(User);

                Email.FirstName = user.FirstName;
                Email.LastName = user.LastName;
                Email.PhoneNumber = user.PhoneNumber;
                Email.Email = user.Email;
                Email.Title = user.JobTitle;
                Email.Affiliation = user.Company;
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
            Emailer.MessageSubject = $"Recruitment Enquiry: {Email.FirstName} {Email.LastName}";
            Emailer.Sender = Email.Email;
            Emailer.MessageBody = $"Requester: {Email.FirstName} {Email.LastName} <br /> " +
                                  $"Affiliation: {Email.Affiliation ?? "NA"} <br /> " +
                                  $"Job Title: {Email.Title ?? "NA"} <br /> " +
                                  $"Contact Email: {Email.Email} <br /> " +
                                  $"Contact Phone: {Email.PhoneNumber} <br /> " +
                                  $"Subject Matter:{Email.Subject} <br /> <br /> " +
                                  $"{Email.Message}";

            Emailer.EnableSsl = true;
            Emailer.IsHtml = true;

            if (await Emailer.Send())
                EmailSent = true;
            else if(Emailer.IsException(out Exception error))
            {
                Logger.LogError(error.Message, error);
            }
            return Page();
        }
    }
}