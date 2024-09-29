using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.DTO.Module.Registration;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entry.Module.Registration;
using Template.Infrastructure.Persistence.Repository.Module.Base;

namespace Template.Infrastructure.Persistence.Repository.Module.Registration;

public class ProductRepository(AppDbContext context) : BaseRepository_0<AppDbContext, Product, OutputProduct, InputIdentifierProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, ProductDTO, InternalPropertiesProductDTO, ExternalPropertiesProductDTO, AuxiliaryPropertiesProductDTO>(context), IProductRepository { }