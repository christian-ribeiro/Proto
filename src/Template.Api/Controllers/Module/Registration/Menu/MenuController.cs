using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.Registration;

public class MenuController(IUnitOfWork unitOfWork, IMenuService service, IUserService userService) : BaseController_1<IMenuService, OutputMenu, InputIdentifierMenu>(unitOfWork, service, userService) { }