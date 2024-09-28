using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Base;

namespace Template.Domain.Interface.Repository.Module.Registration;

public interface IUserRepository : IBaseRepository_0<OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO> { }