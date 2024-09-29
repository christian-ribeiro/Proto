using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputUpdateUser(string name, string email) : BaseInputUpdate<InputUpdateUser>
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
}