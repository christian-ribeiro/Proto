using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputReplaceUserMenu(long menuId, int position, bool favorite, bool visible)
{
    public long MenuId { get; private set; } = menuId;
    public int Position { get; private set; } = position;
    public bool Favorite { get; private set; } = favorite;
    public bool Visible { get; private set; } = visible;
}