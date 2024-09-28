using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputRedefinePasswordForgotPasswordUser(string passwordRecoveryCode, string newPassword)
{
    public string PasswordRecoveryCode { get; private set; } = passwordRecoveryCode;
    public string NewPassword { get; private set; } = newPassword;
}