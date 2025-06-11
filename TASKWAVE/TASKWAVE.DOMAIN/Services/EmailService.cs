using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TASKWAVE.DOMAIN.Services
{
    public class EmailService
    {
        public async Task EnviarEmailAsync(string para, string assunto, string corpo)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("leonardomiguelvs84@gmail.com", "whbx jkor rhlh evqr"),
                EnableSsl = true,
            };

            var mensagem = new MailMessage
            {
                From = new MailAddress("leonardomiguelvs84@gmail.com"),
                Subject = assunto,
                Body = corpo,
                IsBodyHtml = false,
            };

            mensagem.To.Add(para);

            await smtpClient.SendMailAsync(mensagem);
        }
    }
}
