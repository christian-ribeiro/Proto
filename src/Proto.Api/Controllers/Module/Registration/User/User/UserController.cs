using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Registration;

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
    [HttpPost("SendEmailForgotPassword")]
    public async Task<ActionResult<BaseResponseApi<OutputAuthenticateUser>>> SendEmailForgotPassword([FromBody] InputSendEmailForgotPasswordUser inputSendEmailForgotPasswordUser)
    {
        try
        {
            var result = await _userService.SendEmailForgotPassword(inputSendEmailForgotPasswordUser);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [AllowAnonymous]
    [HttpPut("RedefinePasswordForgotPassword")]
    public async Task<ActionResult<BaseResponseApi<OutputAuthenticateUser>>> RedefinePasswordForgotPassword([FromBody] InputRedefinePasswordForgotPasswordUser inputRedefinePasswordForgotPasswordUser)
    {
        try
        {
            var result = _userService.RedefinePasswordForgotPassword(inputRedefinePasswordForgotPasswordUser);
            return await ResponseAsync(result);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPut("RedefinePassword")]
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