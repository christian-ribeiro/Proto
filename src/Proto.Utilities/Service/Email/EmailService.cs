using System.Net;
using System.Net.Mail;
using Proto.Arguments.General;
using Proto.Arguments.General.Session;
using Proto.Utilities.Interface.Service;

namespace Proto.Utilities.Service;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml, SmtpConfiguration? configuration)
    {
        configuration ??=
            new SmtpConfiguration(SessionData.Configuration!["SMTP:Server"]!,
            Convert.ToInt32(SessionData.Configuration!["SMTP:Port"]!),
            SessionData.Configuration!["SMTP:DisplayName"]!,
            SessionData.Configuration!["SMTP:From"]!,
            SessionData.Configuration!["SMTP:Username"]!,
            SessionData.Configuration!["SMTP:Password"]!,
            Convert.ToBoolean(SessionData.Configuration!["SMTP:Ssl"]!),
            SessionData.Configuration!["SMTP:EmailCopy"]!);

        using var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(configuration.FromEmail, configuration.DisplayName);
        mailMessage.To.Add(new MailAddress(toEmail));
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = isBodyHtml;

        if (!string.IsNullOrEmpty(configuration.EmailCopy))
            mailMessage.CC.Add(new MailAddress(configuration.EmailCopy));

        using var smtpClient = new SmtpClient(configuration.Server, configuration.Port)
        {
            Credentials = new NetworkCredential(configuration.Username, configuration.Password),
            EnableSsl = configuration.Ssl
        };

        try
        {
            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Falha ao enviar e-mail.", ex);
        }
    }
}