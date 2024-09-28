using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

public class OutputMenu : BaseOutput<OutputMenu>
{
    #region NotMapped
    [JsonIgnore]
    public override DateTime CreationDate => base.CreationDate;
    [JsonIgnore]
    public override DateTime? ChangeDate => base.ChangeDate;
    [JsonIgnore]
    public override long? CreationUserId => base.CreationUserId;
    [JsonIgnore]
    public override long? ChangeUserId => base.ChangeUserId;
    [JsonIgnore]
    public override OutputUser? CreationUser => base.CreationUser;
    [JsonIgnore]
    public override OutputUser? ChangeUser => base.ChangeUser;
    #endregion

    public string Route { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public int Position { get; set; }
    public long? ParentMenuId { get; set; }

    #region VirtualProperties
    #region Internal
    public OutputMenu? ParentMenu { get; set; }
    #endregion
    #endregion

    public OutputMenu() { }

    public OutputMenu(string route, string description, string icon, int position, long? parentMenuId, OutputMenu? parentMenu)
    {
        Route = route;
        Description = description;
        Icon = icon;
        Position = position;
        ParentMenuId = parentMenuId;
        ParentMenu = parentMenu;
    }
}