using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments.Module.Registration;

public class OutputUser : BaseOutput<OutputUser>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public EnumLanguage Language { get; set; }
    public string? RefreshToken { get; set; }
    public Guid? LoginKey { get; set; }

    public OutputUser() { }

    public OutputUser(string code, string name, string password, string email, EnumLanguage language, string? refreshToken, Guid? loginKey)
    {
        Code = code;
        Name = name;
        Password = password;
        Email = email;
        Language = language;
        RefreshToken = refreshToken;
        LoginKey = loginKey;
    }
}