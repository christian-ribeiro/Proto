using Proto.Domain.DTO.Module.Base;

namespace Proto.Domain.DTO.Module.Registration;

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