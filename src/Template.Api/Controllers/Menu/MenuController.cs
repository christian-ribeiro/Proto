using Template.Api.Controllers.Base;
using Template.Arguments.Arguments;
using Template.Domain.Interface;
using Template.Domain.Interface.Service;

namespace Template.Api.Controllers.Menu;

public class MenuController(IUnitOfWork unitOfWork, IMenuService service, IUserService userService) : BaseController_1<IMenuService, OutputMenu, InputIdentifierMenu>(unitOfWork, service, userService) { }