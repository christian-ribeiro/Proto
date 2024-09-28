using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

public class InputIdentifierBrand : BaseInputIdentifier<InputIdentifierBrand>
{
    public string Code { get; private set; }

    public InputIdentifierBrand() { }

    [JsonConstructor]
    public InputIdentifierBrand(string code)
    {
        Code = code;
    }
}