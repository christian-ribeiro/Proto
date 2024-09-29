using Proto.Arguments.General;

namespace Proto.Utilities.Interface.Service;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false, SmtpConfiguration? configuration = null);
}