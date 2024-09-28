using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

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