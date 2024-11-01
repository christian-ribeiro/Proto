using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Infrastructure.Persistence.Context;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;
using Proto.Infrastructure.Persistence.Repository.Module.Base;

namespace Proto.Infrastructure.Persistence.Repository.Module.Registration;

public class MenuRepository(AppDbContext context) : BaseRepository_0_2<AppDbContext, Menu, OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO>(context), IMenuRepository { }