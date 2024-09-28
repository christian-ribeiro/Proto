using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments.Module.General;

public class InputUpdateEmailConfiguration(string server, int port, string displayName, string fromEmail, string username, string password, bool sSL, EnumEmailConfigurationType emailConfigurationType) : BaseInputUpdate<InputUpdateEmailConfiguration>
{
    public string Server { get; private set; } = server;
    public int Port { get; private set; } = port;
    public string DisplayName { get; private set; } = displayName;
    public string FromEmail { get; private set; } = fromEmail;
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public bool SSL { get; private set; } = sSL;
    public EnumEmailConfigurationType EmailConfigurationType { get; private set; } = emailConfigurationType;
}