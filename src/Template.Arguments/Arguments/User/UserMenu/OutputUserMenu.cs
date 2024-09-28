using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

public class OutputUserMenu(long menuId, int position, bool favorite, bool visible, OutputMenu? menu) : BaseOutput<OutputUserMenu>
{
    public long MenuId { get; set; } = menuId;
    public int Position { get; set; } = position;
    public bool Favorite { get; set; } = favorite;
    public bool Visible { get; set; } = visible;

    #region Virtual Properties
    #region Internal
    public OutputMenu? Menu { get; set; } = menu;
    #endregion
    #endregion
}