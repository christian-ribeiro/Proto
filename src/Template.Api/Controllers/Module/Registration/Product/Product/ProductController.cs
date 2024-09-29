using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.Registration;

public class ProductController(IUnitOfWork unitOfWork, IProductService service, IUserService userService) : BaseController_0<IProductService, OutputProduct, InputIdentifierProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct>(unitOfWork, service, userService) { }