﻿using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Base;

namespace Template.Domain.Interface.Repository.Module.Registration;

public interface IProductCategoryRepository : IBaseRepository_0<OutputProductCategory, InputIdentifierProductCategory, InputCreateProductCategory, InputUpdateProductCategory, InputIdentityUpdateProductCategory, InputIdentityDeleteProductCategory, ProductCategoryDTO, InternalPropertiesProductCategoryDTO, ExternalPropertiesProductCategoryDTO, AuxiliaryPropertiesProductCategoryDTO> { }