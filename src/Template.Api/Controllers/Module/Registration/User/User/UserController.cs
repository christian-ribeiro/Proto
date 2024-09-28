using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.Registration;

public class UserController(IUnitOfWork unitOfWork, IUserService service) : BaseController_0<IUserService, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser>(unitOfWork, service, service)
{
    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public async Task<ActionResult<BaseResponseApi<OutputAuthenticateUser>>> Authenticate([FromBody] InputAuthenticateUser inputAuthenticateUser)
    {
        try
        {
            var result = _userService.Authenticate(inputAuthenticateUser);
            if (result == null)
                return NotFound();

            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [AllowAnonymous]
    [HttpPost("RefreshToken")]
    public async Task<ActionResult<BaseResponseApi<OutputAuthenticateUser>>> RefreshToken([FromBody] InputRefreshTokenUser inputRefreshTokenUser)
    {
        try
        {
            var result = _userService.RefreshToken(inputRefreshTokenUser);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [AllowAnonymous]
    [HttpPost("SendEmailRedefinePassword")]
    public async Task<ActionResult<BaseResponseApi<OutputAuthenticateUser>>> SendEmailRedefinePassword([FromBody] InputSendEmailRedefinePasswordUser inputSendEmailRedefinePasswordUser)
    {
        try
        {
            var result = await _userService.SendEmailRedefinePassword(inputSendEmailRedefinePasswordUser);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [AllowAnonymous]
    [HttpPost("RedefinePassword")]
    public async Task<ActionResult<BaseResponseApi<OutputAuthenticateUser>>> RedefinePassword([FromBody] InputRedefinePasswordUser inputRedefinePasswordUser)
    {
        try
        {
            var result = _userService.RedefinePassword(inputRedefinePasswordUser);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
}