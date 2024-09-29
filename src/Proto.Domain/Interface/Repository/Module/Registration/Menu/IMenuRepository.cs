using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Base;

namespace Proto.Domain.Interface.Repository.Module.Registration;

public interface IMenuRepository : IBaseRepository_1<OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO> { }