using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.Enum;

namespace Proto.Arguments.Arguments.Module.General;

public class OutputEmailConfiguration : BaseOutput<OutputEmailConfiguration>
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string DisplayName { get; set; }
    public string FromEmail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Ssl { get; set; }
    public string? EmailCopy { get; set; }

    public EnumEmailConfigurationType EmailConfigurationType { get; set; }

    public OutputEmailConfiguration() { }

    public OutputEmailConfiguration(string server, int port, string displayName, string fromEmail, string username, string password, bool ssl, string? emailCopy, EnumEmailConfigurationType emailConfigurationType)
    {
        Server = server;
        Port = port;
        DisplayName = displayName;
        FromEmail = fromEmail;
        Username = username;
        Password = password;
        Ssl = ssl;
        EmailCopy = emailCopy;
        EmailConfigurationType = emailConfigurationType;
    }
}