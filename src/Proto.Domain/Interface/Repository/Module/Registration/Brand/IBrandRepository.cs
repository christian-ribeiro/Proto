using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Base;

namespace Proto.Domain.Interface.Repository.Module.Registration;

public interface IBrandRepository : IBaseRepository_0<OutputBrand, InputIdentifierBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, BrandDTO, InternalPropertiesBrandDTO, ExternalPropertiesBrandDTO, AuxiliaryPropertiesBrandDTO> { }