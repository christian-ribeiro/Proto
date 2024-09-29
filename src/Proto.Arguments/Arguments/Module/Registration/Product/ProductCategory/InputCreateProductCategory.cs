using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputCreateProductCategory(string code, string description) : BaseInputCreate<InputCreateProductCategory>
{
    public string Code { get; private set; } = code;
    public string Description { get; private set; } = description;
}