using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

public class InputAuthenticateUser
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    [JsonConstructor]
    public InputAuthenticateUser(string email, string password)
    {
        Email = email;
        Password = password;
    }
}