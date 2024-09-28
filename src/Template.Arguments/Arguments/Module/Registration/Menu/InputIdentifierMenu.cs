using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

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