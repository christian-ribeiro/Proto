using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Registration;

public class MenuController(IUnitOfWork unitOfWork, IMenuService service, IUserService userService) : BaseController_1<IMenuService, OutputMenu, InputIdentifierMenu>(unitOfWork, service, userService) { }