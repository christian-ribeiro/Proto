using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository.Base;

namespace Template.Domain.Interface.Repository;

public interface IMenuRepository : IBaseRepository_1<OutputMenu, InputIdentifierMenu, MenuDTO, InternalPropertiesMenuDTO, AuxiliaryPropertiesMenuDTO> { }