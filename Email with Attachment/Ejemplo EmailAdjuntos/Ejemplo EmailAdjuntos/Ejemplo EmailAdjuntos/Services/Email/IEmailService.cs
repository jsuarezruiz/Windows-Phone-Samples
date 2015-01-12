using System.Threading.Tasks;
using Windows.ApplicationModel.Email;

namespace Ejemplo_EmailAdjuntos.Services.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Send a email with attached files.
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="subject"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        Task Send(string recipient, string subject, EmailAttachment attachment);
    }
}
