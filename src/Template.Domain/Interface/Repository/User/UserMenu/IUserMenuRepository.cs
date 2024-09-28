using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository.Base;

namespace Template.Domain.Interface.Repository;

public interface IUserMenuRepository : IBaseRepository_0<OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu, UserMenuDTO, InternalPropertiesUserMenuDTO, ExternalPropertiesUserMenuDTO, AuxiliaryPropertiesUserMenuDTO> { }