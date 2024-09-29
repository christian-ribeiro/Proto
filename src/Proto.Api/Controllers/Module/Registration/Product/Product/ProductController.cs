using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Registration;

public class ProductController(IUnitOfWork unitOfWork, IProductService service, IUserService userService) : BaseController_0<IProductService, OutputProduct, InputIdentifierProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct>(unitOfWork, service, userService) { }