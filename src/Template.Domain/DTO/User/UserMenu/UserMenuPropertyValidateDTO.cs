using Template.Domain.DTO.Base;

namespace Template.Domain.DTO;

public class UserMenuPropertyValidateDTO : BaseValidateDTO
{
    public UserMenuDTO? OriginalUserMenuDTO { get; private set; }
    public MenuDTO? RelatedMenuDTO { get; private set; }

    public UserMenuPropertyValidateDTO ValidateCreate(UserMenuDTO? originalUserMenuDTO, MenuDTO? relatedMenuDTO)
    {
        OriginalUserMenuDTO = originalUserMenuDTO;
        RelatedMenuDTO = relatedMenuDTO;
        return this;
    }

    public UserMenuPropertyValidateDTO ValidateUpdate(UserMenuDTO? originalUserMenuDTO)
    {
        OriginalUserMenuDTO = originalUserMenuDTO;
        return this;
    }

    public UserMenuPropertyValidateDTO ValidateDelete(UserMenuDTO? originalUserMenuDTO)
    {
        OriginalUserMenuDTO = originalUserMenuDTO;
        return this;
    }
}