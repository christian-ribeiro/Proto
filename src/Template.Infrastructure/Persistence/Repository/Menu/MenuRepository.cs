using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entry;
using Template.Infrastructure.Persistence.Repository.Base;

namespace Template.Infrastructure.Persistence.Repository;

public class MenuRepository(AppDbContext context) : BaseRepository_1<AppDbContext, Menu, OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO>(context), IMenuRepository { }