using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

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