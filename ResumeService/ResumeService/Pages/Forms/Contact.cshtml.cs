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

namespace ResumeService.Pages.Forms
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> Logger;

        public ContactModel(ILogger<ContactModel> _Logger)
        {
            Logger = _Logger;
            EmailSent = false;
        }

        [BindProperty]
        public bool EmailSent { get; set; }

        [BindProperty]
        public EmailModel Email { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<ActionResult> OnPost()
        { 
            using (SmtpClient smtp = new SmtpClient(Resources.SmtpDeliveryServer,587))
            {
                try
                {
                    smtp.Credentials = new NetworkCredential(Resources.SmtpDeliveryUsername,Resources.SmtpDeliveryPassword);
                    smtp.EnableSsl = true;

                    if (Email.Affiliation == null)
                        Email.Affiliation = "NA";

                    if (Email.Title == null)
                        Email.Title = "NA";

                    MailMessage message = new MailMessage()
                    {
                        Body = $"Requester: {Email.FirstName} {Email.LastName} <br /> " +
                               $"Affiliation: {Email.Affiliation} <br /> " +
                               $"Job Title: {Email.Title} <br /> " +
                               $"Contact Email: {Email.Email} <br /> " +
                               $"Contact Phone: {Email.PhoneNumber} <br /> " +
                               $"Subject Matter:{Email.Subject} <br /> <br /> " +
                               $"{Email.Message}" ,
                        Subject = $"Recruitment Enquiry: {Email.FirstName} {Email.LastName}",
                        From = (new MailAddress(Email.Email))
                    };
                    message.IsBodyHtml = true;
                    message.To.Add(Resources.SmtpDeliveryUsername);
                    await smtp.SendMailAsync(message).ConfigureAwait(true);
                }
                catch (Exception exception)
                {
                    Logger.LogError("EMail POST Error", exception);
                    return RedirectToPage("/Error");
                }
            }
            EmailSent = true;
            return Page();
        }
    }
}