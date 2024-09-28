using Template.Domain.DTO.Module.Registration;

namespace Template.Domain.DTO.Module.Base;

public abstract class BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO> where TAuxiliaryPropertyDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO>, new()
{
    public virtual UserDTO? CreationUser { get; private set; }
    public virtual UserDTO? ChangeUser { get; private set; }

    public TAuxiliaryPropertyDTO SetInternalData(UserDTO? creationUser, UserDTO? changeUser)
    {
        CreationUser = creationUser;
        ChangeUser = changeUser;
        return (TAuxiliaryPropertyDTO)this;
    }

    public TAuxiliaryPropertyDTO SetInternalDataCreate(UserDTO? creationUser)
    {
        CreationUser = creationUser;
        return (TAuxiliaryPropertyDTO)this;
    }

    public TAuxiliaryPropertyDTO SetInternalDataChange(UserDTO? changeUser)
    {
        ChangeUser = changeUser;
        return (TAuxiliaryPropertyDTO)this;
    }
}

public class BaseAuxiliaryPropertiesDTO_0 : BaseAuxiliaryPropertiesDTO<BaseAuxiliaryPropertiesDTO_0> { }