using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Service
{
    public class SendMailService
    {
        MailSetting _mailSetting { get; set; }
        MailContent content;
        public SendMailService( )
        {
            
        }

        public SendMailService(IOptions<MailSetting> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }
        public async Task<string> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtp.ConnectAsync(_mailSetting.Host, _mailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSetting.Mail, _mailSetting.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error " + e.Message;
            }

            smtp.Disconnect(true);
            return "Send Mail Successful";
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = message
            });
        }

        public class MailContent
        {
            public MailContent()
            {
            }

            public MailContent(string to, string subject, string body)
            {
                To = to;
                Subject = subject;
                Body = body;
            }

            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }
    }
}
