using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

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