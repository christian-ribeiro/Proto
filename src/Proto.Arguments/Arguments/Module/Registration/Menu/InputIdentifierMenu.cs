using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

public class InputIdentifierMenu : BaseInputIdentifier<InputIdentifierMenu>
{
    public string Route { get; private set; }

    public InputIdentifierMenu() { }

    [JsonConstructor]
    public InputIdentifierMenu(string route)
    {
        Route = route;
    }
}