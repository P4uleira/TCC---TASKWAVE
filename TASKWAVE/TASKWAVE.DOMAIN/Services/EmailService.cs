using TASKWAVE.DOMAIN.ENTITY;
using TASKWAVE.DOMAIN.Interfaces.Repositories;
using TASKWAVE.DOMAIN.Interfaces.Services;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TASKWAVE.DOMAIN.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task EnviarAsync(string para, string assunto, string corpo)
        {
            var smtpHost = _config["Smtp:Host"];
            var smtpPort = _config["Smtp:Port"];
            var smtpUser = _config["Smtp:User"];
            var smtpPass = _config["Smtp:Pass"];

            if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(smtpPort) || string.IsNullOrEmpty(smtpUser) || string.IsNullOrEmpty(smtpPass))
            {
                throw new InvalidOperationException("Configurações de SMTP estão incompletas.");
            }

            using var smtpClient = new SmtpClient
            {
                Host = smtpHost,
                Port = int.Parse(smtpPort),
                EnableSsl = true,
                Credentials = new NetworkCredential(smtpUser, smtpPass)
            };

            var mail = new MailMessage
            {
                From = new MailAddress(smtpUser),
                Subject = assunto,
                Body = corpo,
                IsBodyHtml = true
            };
            mail.To.Add(para);

            await smtpClient.SendMailAsync(mail);
        }
    }
}
