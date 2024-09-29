using Microsoft.AspNetCore.Mvc;
using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Registration;

public class UserMenuController(IUnitOfWork unitOfWork, IUserMenuService service, IUserService userService) : BaseController_0<IUserMenuService, OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu>(unitOfWork, service, userService)
{
    #region Custom
    [HttpPost("Replace/Multiple")]
    public virtual async Task<ActionResult<BaseResponseApi<List<long>>>> Replace([FromBody] List<InputReplaceUserMenu> listInputReplaceUserMenu)
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