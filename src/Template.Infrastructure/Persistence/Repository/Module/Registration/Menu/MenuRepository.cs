using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entity.Module.Registration;
using Template.Infrastructure.Persistence.Repository.Module.Base;

namespace Template.Infrastructure.Persistence.Repository.Module.Registration;

public class MenuRepository(AppDbContext context) : BaseRepository_1<AppDbContext, Menu, OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO>(context), IMenuRepository { }