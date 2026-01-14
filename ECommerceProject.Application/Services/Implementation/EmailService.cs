using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ECommerceProject.Application.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var from = _configuration["EmailSettings:From"];
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);
            var userName = _configuration["EmailSettings:UserName"];
            var password = _configuration["EmailSettings:Password"];

            var message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;

            using var client = new SmtpClient(smtpServer, port)
            {

                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true,

            };

            await client.SendMailAsync(message);

        }
    }
}
