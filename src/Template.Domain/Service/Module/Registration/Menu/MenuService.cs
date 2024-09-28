using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Domain.Interface.Service.Module.Registration;
using Template.Domain.Service.Module.Base;

namespace Template.Domain.Service.Module.Registration;

public class MenuService(IMenuRepository repository) : BaseService_1<IMenuRepository, OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO>(repository), IMenuService { }