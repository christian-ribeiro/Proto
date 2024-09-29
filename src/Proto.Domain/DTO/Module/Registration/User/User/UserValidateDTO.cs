using Proto.Arguments.Arguments.Module.Registration;

namespace Proto.Domain.DTO.Module.Registration;

public class UserValidateDTO : UserPropertyValidateDTO
{
    public InputCreateUser? InputCreateUser { get; private set; }
    public InputIdentityUpdateUser? InputIdentityUpdateUser { get; private set; }
    public InputIdentityDeleteUser? InputIdentityDeleteUser { get; private set; }
    public InputIdentityViewUser? InputIdentityViewUser { get; private set; }

    public UserValidateDTO ValidateCreate(InputCreateUser inputCreateUser, UserDTO? originalUserDTO)
    {
        InputCreateUser = inputCreateUser;
        ValidateCreate(originalUserDTO);
        return this;
    }

    public UserValidateDTO ValidateUpdate(InputIdentityUpdateUser inputIdentityUpdateUser, UserDTO? originalUserDTO)
    {
        InputIdentityUpdateUser = inputIdentityUpdateUser;
        ValidateUpdate(originalUserDTO);
        return this;
    }

    public UserValidateDTO ValidateDelete(InputIdentityDeleteUser inputIdentityDeleteUser, UserDTO? originalUserDTO)
    {
        InputIdentityDeleteUser = inputIdentityDeleteUser;
        ValidateDelete(originalUserDTO);
        return this;
    }

    public UserValidateDTO ValidateView(InputIdentityViewUser? inputIdentityViewUser, UserDTO? originalUserDTO)
    {
        InputIdentityViewUser = inputIdentityViewUser;
        ValidateView(originalUserDTO);
        return this;
    }
}