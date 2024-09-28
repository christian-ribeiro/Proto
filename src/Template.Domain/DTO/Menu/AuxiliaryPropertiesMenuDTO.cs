using System.Text.Json.Serialization;
using Template.Domain.DTO.Base;

namespace Template.Domain.DTO;

public class AuxiliaryPropertiesMenuDTO : BaseAuxiliaryPropertiesDTO<AuxiliaryPropertiesMenuDTO>
{
    #region VirtualProperties
    #region Internal
    public MenuDTO ParentMenu { get; private set; }
    #endregion
    #region External
    public List<MenuDTO> ListMenu { get; private set; }
    #endregion
    #endregion

    public AuxiliaryPropertiesMenuDTO() { }

    [JsonConstructor]
    public AuxiliaryPropertiesMenuDTO(MenuDTO parentMenu, List<MenuDTO> listMenu)
    {
        ParentMenu = parentMenu;
        ListMenu = listMenu;
    }
}