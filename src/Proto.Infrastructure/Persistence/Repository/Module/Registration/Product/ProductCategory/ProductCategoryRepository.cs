using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Infrastructure.Persistence.Context;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;
using Proto.Infrastructure.Persistence.Repository.Module.Base;

namespace Proto.Infrastructure.Persistence.Repository.Module.Registration;

public class ProductCategoryRepository(AppDbContext context) : BaseRepository_0<AppDbContext, ProductCategory, OutputProductCategory, InputIdentifierProductCategory, InputCreateProductCategory, InputUpdateProductCategory, InputIdentityUpdateProductCategory, InputIdentityDeleteProductCategory, ProductCategoryDTO, InternalPropertiesProductCategoryDTO, ExternalPropertiesProductCategoryDTO, AuxiliaryPropertiesProductCategoryDTO>(context), IProductCategoryRepository { }