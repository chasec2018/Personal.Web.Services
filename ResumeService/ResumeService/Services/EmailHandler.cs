using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ResumeService.Properties;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace ResumeService.Services
{
    public class EmailHandler : IEmailSender
    {
        private Exception exception;
        private readonly KeyVaultHandler VaultHandler;

        public EmailHandler(KeyVaultHandler secretVaultHandler)
        {
            VaultHandler = secretVaultHandler;
        }

        public string Sender { get; set; }
        public string MessageBody { get; set; }
        public string MessageSubject { get; set; }
        public bool EnableSsl { get; set; } = false;
        public bool IsHtml { get; set; } = false;


       
        public async Task<bool> Send()
        {
            using (SmtpClient smtp = new SmtpClient(VaultHandler.Secrets.SmtpDeliveryServer, 587))
            {
                try
                {
                    smtp.Credentials = new NetworkCredential(VaultHandler.Secrets.SmtpDeliveryUsername, VaultHandler.Secrets.SmtpDeliveryPassword);
                    smtp.EnableSsl = EnableSsl;

                    MailMessage message = new MailMessage()
                    {
                        Body = MessageBody,
                        Subject = MessageSubject,
                        From = (new MailAddress(Sender))
                    };

                    message.IsBodyHtml = IsHtml;
                    message.To.Add(VaultHandler.Secrets.SmtpDeliveryUsername);
                    await smtp.SendMailAsync(message).ConfigureAwait(true);

                    return true;
                }
                catch(Exception e)
                {
                    exception = e;
                    return false;
                }
            }
        }

        public bool IsException(out Exception Error)
        {
            if (exception != null)
            {
                Error = exception;
                return true;
            }
            else
            {
                Error = null;
                return false;
            }
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (SmtpClient smtp = new SmtpClient(VaultHandler.Secrets.SmtpDeliveryServer, 587))
            {
                try
                {
                    smtp.Credentials = new NetworkCredential(VaultHandler.Secrets.SmtpDeliveryUsername, VaultHandler.Secrets.SmtpDeliveryPassword);
                    smtp.EnableSsl = true;

                    MailMessage message = new MailMessage()
                    {
                        Body = htmlMessage,
                        Subject = subject,
                        From = (new MailAddress(VaultHandler.Secrets.SmtpDeliveryUsername))
                    };

                    message.IsBodyHtml = true;
                    message.To.Add(email);
                    await smtp.SendMailAsync(message);
                }
                catch (Exception e)
                {
                    exception = e;
                }
            }
        }
    }
}
