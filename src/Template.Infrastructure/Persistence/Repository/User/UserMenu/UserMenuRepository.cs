using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entry;
using Template.Infrastructure.Persistence.Repository.Base;

namespace Template.Infrastructure.Persistence.Repository;

public class UserMenuRepository(AppDbContext context) : BaseRepository_0<AppDbContext, UserMenu, OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu, UserMenuDTO, InternalPropertiesUserMenuDTO, ExternalPropertiesUserMenuDTO, AuxiliaryPropertiesUserMenuDTO>(context), IUserMenuRepository { }