using System.Text.Json.Serialization;
using Template.Arguments.Enum;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.General;

public class ExternalPropertiesEmailConfigurationDTO : BaseExternalPropertiesDTO<ExternalPropertiesEmailConfigurationDTO>
{
    public string Server { get; private set; }
    public int Port { get; private set; }
    public string DisplayName { get; private set; }
    public string FromEmail { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool Ssl { get; private set; }
    public string? EmailCopy { get; private set; }
    public EnumEmailConfigurationType EmailConfigurationType { get; private set; }

    public ExternalPropertiesEmailConfigurationDTO() { }

    [JsonConstructor]
    public ExternalPropertiesEmailConfigurationDTO(string server, int port, string displayName, string fromEmail, string username, string password, bool ssl, string? emailCopy, EnumEmailConfigurationType emailConfigurationType)
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