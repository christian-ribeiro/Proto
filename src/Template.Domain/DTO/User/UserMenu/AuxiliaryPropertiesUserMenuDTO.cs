using System.Text.Json.Serialization;
using Template.Domain.DTO.Base;

namespace Template.Domain.DTO;

public class AuxiliaryPropertiesUserMenuDTO : BaseAuxiliaryPropertiesDTO<AuxiliaryPropertiesUserMenuDTO>
{
    #region VirtualProperties
    #region Internal
    public UserMenuDTO? UserMenu { get; private set; }
    #endregion
    #endregion

    public AuxiliaryPropertiesUserMenuDTO() { }

    [JsonConstructor]
    public AuxiliaryPropertiesUserMenuDTO(UserMenuDTO? userMenu)
    {
        UserMenu = userMenu;
    }
}