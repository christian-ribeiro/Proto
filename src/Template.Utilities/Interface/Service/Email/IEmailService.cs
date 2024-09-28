using Template.Arguments.General;

namespace Template.Utilities.Interface.Service;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false, SmtpConfiguration? configuration = null);
}