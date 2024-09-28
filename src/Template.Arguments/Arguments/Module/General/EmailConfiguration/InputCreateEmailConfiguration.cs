using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments.Module.General;

[method: JsonConstructor]
public class InputCreateEmailConfiguration(string server, int port, string displayName, string fromEmail, string username, string password, bool ssl, string? emailCopy, EnumEmailConfigurationType emailConfigurationType) : BaseInputCreate<InputCreateEmailConfiguration>
{
    public string Server { get; private set; } = server;
    public int Port { get; private set; } = port;
    public string DisplayName { get; private set; } = displayName;
    public string FromEmail { get; private set; } = fromEmail;
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public bool Ssl { get; private set; } = ssl;
    public string? EmailCopy { get; private set; } = emailCopy;
    public EnumEmailConfigurationType EmailConfigurationType { get; private set; } = emailConfigurationType;
}