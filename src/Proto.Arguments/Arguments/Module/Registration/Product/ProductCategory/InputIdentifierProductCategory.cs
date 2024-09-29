using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

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