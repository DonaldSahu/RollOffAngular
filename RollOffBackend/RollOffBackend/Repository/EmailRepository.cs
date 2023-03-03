using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using RollOffBackend.DTO;
using RollOffBackend.Helpers;
using System;
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
            //Creating the message.
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            //Sending the email.
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("donaldshr998@outlook.com", "yaqdmxqckrpnnguo");
            await Task.Delay(5000);
            smtp.Send(email);
            smtp.Disconnect(true);

        }

        public async void PasswordVerificationEmail(ForgotPasswordDTO forgotPasswordDTO,string token)
        {
            var emailMessage = new MimeMessage();
            var from = config["EmailSettings:EmailUsername"];
            emailMessage.From.Add(new MailboxAddress("SenderLink", from));
            emailMessage.To.Add(new MailboxAddress(forgotPasswordDTO.Email, forgotPasswordDTO.Email));
            emailMessage.Subject = "Reset Password Token";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(EmailBody.EmailStringBody(forgotPasswordDTO.Email,token))
            };

            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate(config["EmailSettings:EmailUsername"],config["EmailSettings:EmailPassword"]);
                    smtp.Send(emailMessage);
                    await Task.Delay(3000);
                }
                catch(Exception e)
                {
                    throw;
                }
                finally
                {
                    smtp.Disconnect(true);
                    smtp.Dispose();
                }
            }
        }
    }
}
