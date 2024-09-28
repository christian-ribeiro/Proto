using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Base;

namespace Template.Domain.Interface.Repository.Module.Registration;

public interface IMenuRepository : IBaseRepository_1<OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO> { }