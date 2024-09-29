using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputUpdateProductCategory(string description) : BaseInputUpdate<InputUpdateProductCategory>
{
    public string Description { get; private set; } = description;
}