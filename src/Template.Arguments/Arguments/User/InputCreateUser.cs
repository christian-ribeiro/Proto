using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;
using Template.Arguments.Enum;

namespace Template.Arguments.Arguments;

[method: JsonConstructor]
public class InputCreateUser(string code, string name, string password, string email, EnumLanguage language) : BaseInputCreate<InputCreateUser>
{
    public string Code { get; private set; } = code;
    public string Name { get; private set; } = name;
    public string Password { get; private set; } = password;
    public string Email { get; private set; } = email;
    public EnumLanguage Language { get; private set; } = language;
}