using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository;
using Template.Domain.Interface.Service;
using Template.Domain.Service.Base;

namespace Template.Domain.Service;

public class MenuService(IMenuRepository repository) : BaseService_1<IMenuRepository, OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO>(repository), IMenuService { }