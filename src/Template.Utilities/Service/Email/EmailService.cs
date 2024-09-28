using System.Net;
using System.Net.Mail;
using Template.Arguments.General;
using Template.Arguments.General.Session;
using Template.Utilities.Interface.Service;

namespace Template.Utilities.Service;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml, SmtpConfiguration? configuration)
    {
        if (configuration == null)
            throw new Exception("Configuração SMTP inválida");

        string smtpServer = configuration.SmtpServer;
        int smtpPort = configuration.SmtpPort;
        string displayName = configuration.DisplayName;
        string fromEmail = configuration.FromEmail;
        string username = configuration.Username;
        string password = configuration.Password;
        bool enableSsl = configuration.EnableSsl;

        using var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(fromEmail, displayName);
        mailMessage.To.Add(new MailAddress(toEmail));
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = isBodyHtml;

        if (!string.IsNullOrEmpty(configuration?.EmailCopy))
            mailMessage.CC.Add(new MailAddress(configuration!.EmailCopy));

        using var smtpClient = new SmtpClient(smtpServer, smtpPort)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = enableSsl
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