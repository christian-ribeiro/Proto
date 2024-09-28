using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

public class InputIdentifierUser : BaseInputIdentifier<InputIdentifierUser>
{
    public string Email { get; private set; }

    public InputIdentifierUser() { }

    [JsonConstructor]
    public InputIdentifierUser(string email)
    {
        Email = email;
    }
}