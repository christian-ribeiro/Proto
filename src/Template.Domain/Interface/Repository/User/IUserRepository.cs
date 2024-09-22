using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository.Base;

namespace Template.Domain.Interface.Repository;

public interface IUserRepository : IBaseRepository_0<OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO> { }