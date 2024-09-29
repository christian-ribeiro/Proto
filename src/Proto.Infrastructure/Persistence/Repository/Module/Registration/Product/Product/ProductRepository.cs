using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Infrastructure.Persistence.Context;
using Proto.Infrastructure.Persistence.Entity.Module.Registration;
using Proto.Infrastructure.Persistence.Repository.Module.Base;

namespace Proto.Infrastructure.Persistence.Repository.Module.Registration;

public class ProductRepository(AppDbContext context) : BaseRepository_0<AppDbContext, Product, OutputProduct, InputIdentifierProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, ProductDTO, InternalPropertiesProductDTO, ExternalPropertiesProductDTO, AuxiliaryPropertiesProductDTO>(context), IProductRepository { }