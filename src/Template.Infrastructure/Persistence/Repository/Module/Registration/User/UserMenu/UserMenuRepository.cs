using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entry.Module.Registration;
using Template.Infrastructure.Persistence.Repository.Module.Base;

namespace Template.Infrastructure.Persistence.Repository.Module.Registration;

public class UserMenuRepository(AppDbContext context) : BaseRepository_0<AppDbContext, UserMenu, OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu, UserMenuDTO, InternalPropertiesUserMenuDTO, ExternalPropertiesUserMenuDTO, AuxiliaryPropertiesUserMenuDTO>(context), IUserMenuRepository { }