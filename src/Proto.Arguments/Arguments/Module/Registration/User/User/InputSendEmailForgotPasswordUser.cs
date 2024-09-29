using System.Text.Json.Serialization;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputSendEmailForgotPasswordUser(string email)
{
    public string Email { get; private set; } = email;
}