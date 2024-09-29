using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entity.Module.Registration;
using Template.Infrastructure.Persistence.Repository.Module.Base;

namespace Template.Infrastructure.Persistence.Repository.Module.Registration;

public class ProductCategoryRepository(AppDbContext context) : BaseRepository_0<AppDbContext, ProductCategory, OutputProductCategory, InputIdentifierProductCategory, InputCreateProductCategory, InputUpdateProductCategory, InputIdentityUpdateProductCategory, InputIdentityDeleteProductCategory, ProductCategoryDTO, InternalPropertiesProductCategoryDTO, ExternalPropertiesProductCategoryDTO, AuxiliaryPropertiesProductCategoryDTO>(context), IProductCategoryRepository { }