using Planificalo.Shared.Responses;

namespace Planificalo.Backend.Helpers
{
    public interface IMailHelper
    {
        ActionResponse<string> SendEmail(string toName, string toEmail, string subject, string body, string language);
    }
}