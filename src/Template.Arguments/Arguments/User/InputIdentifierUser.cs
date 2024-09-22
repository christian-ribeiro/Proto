using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

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