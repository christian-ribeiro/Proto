using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Registration;

public class BrandController(IUnitOfWork unitOfWork, IBrandService service, IUserService userService) : BaseController_0<IBrandService, OutputBrand, InputIdentifierBrand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand>(unitOfWork, service, userService) { }
