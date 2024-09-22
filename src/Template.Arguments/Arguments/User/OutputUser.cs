using Template.Arguments.Arguments.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments;

public class OutputUser(string code, string name, string password, string email, EnumLanguage language, string refreshToken, Guid loginKey) : BaseOutput<OutputUser>
{
    public string Code { get; set; } = code;
    public string Name { get; set; } = name;
    public string Password { get; set; } = password;
    public string Email { get; set; } = email;
    public EnumLanguage Language { get; set; } = language;
    public string RefreshToken { get; private set; } = refreshToken;
    public Guid LoginKey { get; private set; } = loginKey;
}