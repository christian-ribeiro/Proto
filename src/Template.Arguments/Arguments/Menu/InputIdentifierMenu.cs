using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

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