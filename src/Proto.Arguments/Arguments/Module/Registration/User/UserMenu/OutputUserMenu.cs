using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

public class OutputUserMenu : BaseOutput<OutputUserMenu>
{
    public long MenuId { get; set; }
    public int Position { get; set; }
    public bool Favorite { get; set; }
    public bool Visible { get; set; }

    #region Virtual Properties
    #region Internal
    public OutputMenu? Menu { get; set; }
    #endregion
    #endregion

    public OutputUserMenu() { }

    public OutputUserMenu(long menuId, int position, bool favorite, bool visible, OutputMenu? menu)
    {
        MenuId = menuId;
        Position = position;
        Favorite = favorite;
        Visible = visible;
        Menu = menu;
    }
}