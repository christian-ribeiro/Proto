using Template.Api.Controllers.Base;
using Template.Arguments.Arguments;
using Template.Domain.Interface;
using Template.Domain.Interface.Service;

namespace Template.Api.Controllers;

public class UserMenuController(IUnitOfWork unitOfWork, IUserMenuService service, IUserService userService) : BaseController_0<IUserMenuService, OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu>(unitOfWork, service, userService) { }