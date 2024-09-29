namespace Proto.Arguments.General
{
    public class SmtpConfiguration(string server, int port, string displayName, string fromEmail, string username, string password, bool ssl, string? emailCopy)
    {
        public string Server { get; private set; } = server;
        public int Port { get; private set; } = port;
        public string DisplayName { get; private set; } = displayName;
        public string FromEmail { get; private set; } = fromEmail;
        public string Username { get; private set; } = username;
        public string Password { get; private set; } = password;
        public bool Ssl { get; private set; } = ssl;
        public string? EmailCopy { get; private set; } = emailCopy;
    }
}