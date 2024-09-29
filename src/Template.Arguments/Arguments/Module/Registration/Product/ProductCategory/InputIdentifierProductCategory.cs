using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

public class InputIdentifierProductCategory : BaseInputIdentifier<InputIdentifierProductCategory>
{
    public string Code { get; private set; }

    public InputIdentifierProductCategory() { }

    [JsonConstructor]
    public InputIdentifierProductCategory(string code)
    {
        Code = code;
    }
}