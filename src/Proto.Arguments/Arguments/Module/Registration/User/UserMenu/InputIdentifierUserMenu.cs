using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

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