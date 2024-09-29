using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputUpdateProductCategory(string description) : BaseInputUpdate<InputUpdateProductCategory>
{
    public string Description { get; private set; } = description;
}