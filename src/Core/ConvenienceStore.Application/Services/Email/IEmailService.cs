using ConvenienceStore.Application.Models.Messages;

namespace ConvenienceStore.Application.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, EmailMessage message, CancellationToken cancellationToken = default);
    }
}
