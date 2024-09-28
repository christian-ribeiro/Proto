using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputRedefinePasswordUser(string passwordRecoveryCode, string newPassword)
{
    public string PasswordRecoveryCode { get; private set; } = passwordRecoveryCode;
    public string NewPassword { get; private set; } = newPassword;
}