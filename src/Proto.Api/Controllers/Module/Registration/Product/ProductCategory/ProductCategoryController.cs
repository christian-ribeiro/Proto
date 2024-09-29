using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Registration;

public class ProductCategoryController(IUnitOfWork unitOfWork, IProductCategoryService service, IUserService userService) : BaseController_0<IProductCategoryService, OutputProductCategory, InputIdentifierProductCategory, InputCreateProductCategory, InputUpdateProductCategory, InputIdentityUpdateProductCategory, InputIdentityDeleteProductCategory>(unitOfWork, service, userService) { }