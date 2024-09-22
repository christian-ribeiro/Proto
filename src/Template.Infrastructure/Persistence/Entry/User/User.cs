using Template.Arguments.Enum;
using Template.Infrastructure.Persistence.Entry.Base;

namespace Template.Infrastructure.Persistence.Entry;

public class User(string code, string name, string password, string email, EnumLanguage language) : BaseEntry<User>
{
    public string Code { get; private set; } = code;
    public string Name { get; private set; } = name;
    public string Password { get; private set; } = password;
    public string Email { get; private set; } = email;
    public EnumLanguage Language { get; private set; } = language;
}