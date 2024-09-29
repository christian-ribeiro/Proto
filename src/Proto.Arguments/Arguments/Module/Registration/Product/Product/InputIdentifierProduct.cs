using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

public class InputIdentifierProduct : BaseInputIdentifier<InputIdentifierProduct>
{
    public string Code { get; private set; }

    public InputIdentifierProduct() { }

    [JsonConstructor]
    public InputIdentifierProduct(string code)
    {
        Code = code;
    }
}