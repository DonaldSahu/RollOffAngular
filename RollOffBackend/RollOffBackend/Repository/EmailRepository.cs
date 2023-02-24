
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using RollOffBackend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public class EmailRepository:IEmailRepository
    {
        private readonly IConfiguration config;

        public EmailRepository(IConfiguration config)
        {
            this.config = config;
        }

        public async void SendEmail(EmailDTO request)
        {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = "Test Email Subject";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

                //send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("donaldshr998@outlook.com", "yaqdmxqckrpnnguo");
            await Task.Delay(5000);
                smtp.Send(email);
                smtp.Disconnect(true);

        }
    }
}
