using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.Enum;

namespace Proto.Arguments.Arguments.Module.Registration;

public class OutputUser : BaseOutput_0_1<OutputUser>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public EnumLanguage Language { get; set; }
    public string? RefreshToken { get; set; }
    public Guid? LoginKey { get; set; }
    public string? PasswordRecoveryCode { get; set; }

    public OutputUser() { }

    public OutputUser(string code, string name, string password, string email, EnumLanguage language, string? refreshToken, Guid? loginKey, string? passwordRecoveryCode)
    {
        Code = code;
        Name = name;
        Password = password;
        Email = email;
        Language = language;
        RefreshToken = refreshToken;
        LoginKey = loginKey;
        PasswordRecoveryCode = passwordRecoveryCode;
    }
}