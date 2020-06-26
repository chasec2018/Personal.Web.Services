using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResumeService.Services;
using Microsoft.AspNetCore.Identity;
using ResumeService.Areas.Identity.EntityModels;

namespace ResumeService.Pages.Forms
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> Logger;
        private readonly EmailHandler Emailer;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly SignInManager<ResumeServiceUsers> SignInManager;

        public ContactModel(ILogger<ContactModel> logger, EmailHandler emailHandler, UserManager<ResumeServiceUsers> userManager, SignInManager<ResumeServiceUsers> signInManager)
        {
            Logger = logger;
            Emailer = emailHandler;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [BindProperty(SupportsGet = true)]
        public bool EmailSent { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Affiliation { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PhoneNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Subject { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CSharpCode { get; set; } = @"
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResumeService.Services;
using Microsoft.AspNetCore.Identity;
using ResumeService.Areas.Identity.EntityModels;

namespace ResumeService.Pages.Forms
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> Logger;
        private readonly EmailHandler Emailer;
        private readonly UserManager<ResumeServiceUsers> UserManager;
        private readonly SignInManager<ResumeServiceUsers> SignInManager;

        public ContactModel(ILogger<ContactModel> logger, EmailHandler emailHandler, UserManager<ResumeServiceUsers> userManager, SignInManager<ResumeServiceUsers> signInManager)
        {
            Logger = logger;
            Emailer = emailHandler;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [BindProperty(SupportsGet = true)]
        public bool EmailSent { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Affiliation { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PhoneNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Subject { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }


        public async Task OnGetAsync()
        {
            if (SignInManager.IsSignedIn(User))
            {
                ResumeServiceUsers user = await UserManager.GetUserAsync(User);

                FirstName = user.FirstName;
                LastName = user.LastName;
                PhoneNumber = user.PhoneNumber;
                Email = user.Email;
                Title = user.JobTitle;
                Affiliation = user.Company;
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
            Emailer.MessageSubject = $'Recruitment Enquiry: {FirstName
    } {LastName
}';
            Emailer.Sender = Email;
            Emailer.MessageBody = $'Requester: {FirstName} {LastName} <br /> ' +
                                  $'Affiliation: {Affiliation ?? 'NA'} <br /> ' +
                                  $'Job Title: {Title ?? 'NA'} <br /> ' +
                                  $'Contact Email: {Email} <br /> ' +
                                  $'Contact Phone: {PhoneNumber} <br /> ' +
                                  $'Subject Matter:{Subject} <br /> <br /> ' +
                                  $'{Message}';

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
";


        public async Task OnGetAsync()
        {
            if (SignInManager.IsSignedIn(User))
            {
                ResumeServiceUsers user = await UserManager.GetUserAsync(User);

                FirstName = user.FirstName;
                LastName = user.LastName;
                PhoneNumber = user.PhoneNumber;
                Email = user.Email;
                Title = user.JobTitle;
                Affiliation = user.Company;
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
            Emailer.MessageSubject = $"Recruitment Enquiry: {FirstName} {LastName}";
            Emailer.Sender = Email;
            Emailer.MessageBody = $"Requester: {FirstName} {LastName} <br /> " +
                                  $"Affiliation: {Affiliation ?? "NA"} <br /> " +
                                  $"Job Title: {Title ?? "NA"} <br /> " +
                                  $"Contact Email: {Email} <br /> " +
                                  $"Contact Phone: {PhoneNumber} <br /> " +
                                  $"Subject Matter:{Subject} <br /> <br /> " +
                                  $"{Message}";

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