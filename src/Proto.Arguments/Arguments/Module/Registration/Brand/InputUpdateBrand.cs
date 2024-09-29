using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputUpdateBrand(string description) : BaseInputUpdate<InputUpdateBrand>
{
    public string Description { get; private set; } = description;
}