using System.Text.Json.Serialization;
using Template.Infrastructure.Persistence.Entry.Module.Base;

namespace Template.Infrastructure.Persistence.Entry.Module.Registration;

public class UserMenu : BaseEntry<UserMenu>
{
    public long MenuId { get; private set; }
    public int Position { get; private set; }
    public bool Favorite { get; private set; }
    public bool Visible { get; private set; }

    #region Virtual Properties
    #region Internal
    public virtual Menu? Menu { get; private set; }
    #endregion
    #endregion

    public UserMenu() { }

    [JsonConstructor]
    public UserMenu(long menuId, int position, bool favorite, bool visible, Menu? menu)
    {
        MenuId = menuId;
        Position = position;
        Favorite = favorite;
        Visible = visible;
        Menu = menu;
    }
}