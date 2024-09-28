using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputUpdateBrand(string description) : BaseInputUpdate<InputUpdateBrand>
{
    public string Description { get; private set; } = description;
}