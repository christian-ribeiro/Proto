using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.Registration;

public class BrandController(IUnitOfWork unitOfWork, IBrandService service, IUserService userService) : BaseController_0<IBrandService, OutputBrand, InputIdentifierBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand>(unitOfWork, service, userService) { }
