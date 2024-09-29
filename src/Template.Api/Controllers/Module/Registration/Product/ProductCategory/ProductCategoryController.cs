using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.Registration;

public class ProductCategoryController(IUnitOfWork unitOfWork, IProductCategoryService service, IUserService userService) : BaseController_0<IProductCategoryService, OutputProductCategory, InputIdentifierProductCategory, InputCreateProductCategory, InputUpdateProductCategory, InputIdentityUpdateProductCategory, InputIdentityDeleteProductCategory>(unitOfWork, service, userService) { }