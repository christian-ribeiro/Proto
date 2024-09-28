using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

public class OutputMenu(string route, string description, string icon, int position, long? parentMenuId, OutputMenu? parentMenu) : BaseOutput<OutputMenu>
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

    public string Route { get; set; } = route;
    public string Description { get; set; } = description;
    public string Icon { get; set; } = icon;
    public int Position { get; set; } = position;
    public long? ParentMenuId { get; set; } = parentMenuId;

    #region VirtualProperties
    #region Internal
    public OutputMenu? ParentMenu { get; private set; } = parentMenu;
    #endregion
    #endregion
}