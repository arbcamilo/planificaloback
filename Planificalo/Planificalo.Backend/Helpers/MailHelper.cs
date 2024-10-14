using MailKit.Net.Smtp;
using MimeKit;
using Planificalo.Shared.Responses;
using Microsoft.Extensions.Configuration;

namespace Planificalo.Backend.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResponse<string> SendEmail(string toName, string toEmail, string subject, string body, string language)
        {
            try
            {
                var from = _configuration["Email:From"];
                var name = _configuration["Email:NameEn"];
                if (language == "es")
                {
                    name = _configuration["Email:Name"];
                }
                var smtp = _configuration["Email:Smtp"];
                var port = _configuration["Email:Port"];
                var password = _configuration["Email:Password"];

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name, from));
                message.To.Add(new MailboxAddress(toName, toEmail));
                message.Subject = subject;
                BodyBuilder bodyBuilder = new()
                {
                    HtmlBody = body
                };
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect(smtp, int.Parse(port), false);
                    client.Authenticate(from, password);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return new ActionResponse<string>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<string>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}