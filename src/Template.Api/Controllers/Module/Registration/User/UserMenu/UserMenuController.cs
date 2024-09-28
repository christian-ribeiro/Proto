using Microsoft.AspNetCore.Mvc;
using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.Registration;

public class UserMenuController(IUnitOfWork unitOfWork, IUserMenuService service, IUserService userService) : BaseController_0<IUserMenuService, OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu>(unitOfWork, service, userService)
{
    #region Custom
    [HttpPost("Replace/Multiple")]
    public virtual async Task<ActionResult<BaseResponseApi<List<long>>>> Replace(List<InputReplaceUserMenu> listInputReplaceUserMenu)
    {
        try
        {
            return await ResponseAsync(_service?.Replace(listInputReplaceUserMenu), 201);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion
}