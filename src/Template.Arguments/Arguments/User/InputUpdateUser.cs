using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

[method: JsonConstructor]
public class InputUpdateUser(string name, string email) : BaseInputUpdate<InputUpdateUser>
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
}