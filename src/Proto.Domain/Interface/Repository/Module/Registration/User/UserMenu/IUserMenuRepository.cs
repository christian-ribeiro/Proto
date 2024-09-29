using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Base;

namespace Proto.Domain.Interface.Repository.Module.Registration;

public interface IUserMenuRepository : IBaseRepository_0<OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu, UserMenuDTO, InternalPropertiesUserMenuDTO, ExternalPropertiesUserMenuDTO, AuxiliaryPropertiesUserMenuDTO> { }