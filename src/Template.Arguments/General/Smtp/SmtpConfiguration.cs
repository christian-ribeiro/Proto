namespace Template.Arguments.General
{
    public class SmtpConfiguration(string smtpServer, int smtpPort, string displayName, string fromEmail, string username, string password, bool enableSsl, string? emailCopy)
    {
        public string SmtpServer { get; private set; } = smtpServer;
        public int SmtpPort { get; private set; } = smtpPort;
        public string DisplayName { get; private set; } = displayName;
        public string FromEmail { get; private set; } = fromEmail;
        public string Username { get; private set; } = username;
        public string Password { get; private set; } = password;
        public bool EnableSsl { get; private set; } = enableSsl;
        public string? EmailCopy { get; private set; } = emailCopy;
    }
}