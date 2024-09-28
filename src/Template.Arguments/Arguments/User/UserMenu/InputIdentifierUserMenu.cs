using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

public class InputIdentifierUserMenu : BaseInputIdentifier<InputIdentifierUserMenu>
{
    public long CreationUserId { get; private set; }
    public long MenuId { get; private set; }

    public InputIdentifierUserMenu() { }

    [JsonConstructor]
    public InputIdentifierUserMenu(long creationUserId, long menuId)
    {
        CreationUserId = creationUserId;
        MenuId = menuId;
    }
}