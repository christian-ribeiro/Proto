using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments.Module.General;

public class InputIdentifierEmailConfiguration : BaseInputIdentifier<InputIdentifierEmailConfiguration>
{
    public string FromEmail { get; private set; }
    public EnumEmailConfigurationType EmailConfigurationType { get; private set; }

    public InputIdentifierEmailConfiguration() { }

    [JsonConstructor]
    public InputIdentifierEmailConfiguration(string fromEmail, EnumEmailConfigurationType emailConfigurationType)
    {
        FromEmail = fromEmail;
        EmailConfigurationType = emailConfigurationType;
    }
}