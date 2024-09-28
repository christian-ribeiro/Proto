using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputCreateBrand(string code, string description) : BaseInputCreate<InputCreateBrand>
{
    public string Code { get; set; } = code;
    public string Description { get; set; } = description;
}