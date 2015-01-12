using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;

namespace Ejemplo_EmailAdjuntos.Services.Email
{
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Send a email with attached files.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="subject"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public async Task Send(string recipient, string subject, EmailAttachment attachment)
        {
            var email = new EmailMessage();
            email.To.Add(new EmailRecipient(recipient));
            email.Subject = subject;
            email.Attachments.Add(attachment);

            await EmailManager.ShowComposeNewEmailAsync(email);
        }
    }
}
