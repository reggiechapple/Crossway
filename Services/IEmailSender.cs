using System.Threading.Tasks;

namespace Crossways.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
