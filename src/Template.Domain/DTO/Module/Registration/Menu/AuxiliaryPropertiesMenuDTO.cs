using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class AuxiliaryPropertiesMenuDTO : BaseAuxiliaryPropertiesDTO<AuxiliaryPropertiesMenuDTO>
{
    #region VirtualProperties
    #region Internal
    public MenuDTO? ParentMenu { get; private set; }
    #endregion
    #region External
    public List<MenuDTO>? ListMenu { get; private set; }
    public List<UserMenuDTO>? ListUserMenu { get; private set; }
    #endregion
    #endregion

    public AuxiliaryPropertiesMenuDTO() { }

    [JsonConstructor]
    public AuxiliaryPropertiesMenuDTO(MenuDTO? parentMenu, List<MenuDTO>? listMenu, List<UserMenuDTO>? listUserMenu)
    {
        ParentMenu = parentMenu;
        ListMenu = listMenu;
        ListUserMenu = listUserMenu;
    }
}