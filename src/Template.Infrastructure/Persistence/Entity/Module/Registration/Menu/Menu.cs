using System.Text.Json.Serialization;
using Template.Infrastructure.Persistence.Entity.Module.Base;

namespace Template.Infrastructure.Persistence.Entity.Module.Registration;

public class Menu : BaseEntity<Menu>
{
    public string Route { get; private set; }
    public string Description { get; private set; }
    public string Icon { get; private set; }
    public int Position { get; private set; }
    public long? ParentMenuId { get; private set; }

    #region Virtual Properties
    #region Internal
    public virtual Menu? ParentMenu { get; private set; }
    #endregion
    #region External
    public virtual List<Menu>? ListMenu { get; private set; }
    public virtual List<UserMenu>? ListUserMenu { get; private set; }
    #endregion
    #endregion

    public Menu() { }

    [JsonConstructor]
    public Menu(string route, string description, string icon, int position, long? parentMenuId, Menu? parentMenu, List<Menu>? listMenu, List<UserMenu>? listUserMenu)
    {
        Route = route;
        Description = description;
        Icon = icon;
        Position = position;
        ParentMenuId = parentMenuId;
        ParentMenu = parentMenu;
        ListMenu = listMenu;
        ListUserMenu = listUserMenu;
    }
}