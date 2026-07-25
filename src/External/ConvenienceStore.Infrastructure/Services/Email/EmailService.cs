using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Services.Email;
using ConvenienceStore.Contract.Settings.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ConvenienceStore.Infrastructure.Services.Email
{
    internal class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IOptions<EmailSettings> options,
            ILogger<EmailService> logger)
        {
            _settings = options.Value;
            _logger = logger;
        }

        public async Task
            SendEmailAsync(string to, EmailMessage message, CancellationToken cancellationToken = default)
        {
            using var client = new SmtpClient(_settings.SmtpServer, _settings.SmtpPort)
            {
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.AppPassword),

                EnableSsl = _settings.EnableSsl,
                Timeout = _settings.Timeout
            };

            using var mail = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),

                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            mail.To.Add(to);

            try
            {
                await client.SendMailAsync(mail, cancellationToken);

                _logger.LogInformation("Email sent to {Email}", to);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", to);

                throw;
            }
        }
    }
}
