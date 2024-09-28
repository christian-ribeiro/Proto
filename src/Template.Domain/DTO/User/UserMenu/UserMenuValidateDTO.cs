using Template.Arguments.Arguments;

namespace Template.Domain.DTO;

public class UserMenuValidateDTO : UserMenuPropertyValidateDTO
{
    public InputCreateUserMenu? InputCreateUserMenu { get; private set; }
    public InputIdentityUpdateUserMenu? InputIdentityUpdateUserMenu { get; private set; }
    public InputIdentityDeleteUserMenu? InputIdentityDeleteUserMenu { get; private set; }

    public UserMenuValidateDTO ValidateCreate(InputCreateUserMenu inputCreateUserMenu, UserMenuDTO? originalUserMenuDTO, MenuDTO relatedMenuDTO)
    {
        InputCreateUserMenu = inputCreateUserMenu;
        ValidateCreate(originalUserMenuDTO, relatedMenuDTO);
        return this;
    }

    public UserMenuValidateDTO ValidateUpdate(InputIdentityUpdateUserMenu inputIdentityUpdateUserMenu, UserMenuDTO? originalUserMenuDTO)
    {
        InputIdentityUpdateUserMenu = inputIdentityUpdateUserMenu;
        ValidateUpdate(originalUserMenuDTO);
        return this;
    }

    public UserMenuValidateDTO ValidateDelete(InputIdentityDeleteUserMenu inputIdentityDeleteUserMenu, UserMenuDTO? originalUserMenuDTO)
    {
        InputIdentityDeleteUserMenu = inputIdentityDeleteUserMenu;
        ValidateDelete(originalUserMenuDTO);
        return this;
    }
}