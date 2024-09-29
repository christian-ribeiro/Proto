using System.Text.Json.Serialization;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputRedefinePasswordUser(string currentPassword, string newPassword, string confirmNewPassword)
{
    public string CurrentPassword { get; private set; } = currentPassword;
    public string NewPassword { get; private set; } = newPassword;
    public string ConfirmNewPassword { get; private set; } = confirmNewPassword;
}