using Template.Domain.DTO.Base;

namespace Template.Domain.DTO;

public class UserPropertyValidateDTO : BaseValidateDTO
{
    public UserDTO? OriginalUserDTO { get; private set; }

    public UserPropertyValidateDTO ValidateCreate(UserDTO? originalUserDTO)
    {
        OriginalUserDTO = originalUserDTO;
        return this;
    }

    public UserPropertyValidateDTO ValidateUpdate(UserDTO? originalUserDTO)
    {
        OriginalUserDTO = originalUserDTO;
        return this;
    }

    public UserPropertyValidateDTO ValidateDelete(UserDTO? originalUserDTO)
    {
        OriginalUserDTO = originalUserDTO;
        return this;
    }

    public UserPropertyValidateDTO ValidateView(UserDTO? originalUserDTO)
    {
        OriginalUserDTO = originalUserDTO;
        return this;
    }
}