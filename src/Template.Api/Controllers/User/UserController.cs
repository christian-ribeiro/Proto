using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Controllers.Base;
using Template.Arguments.Arguments;
using Template.Arguments.Arguments.Base;
using Template.Domain.Interface.Service;

namespace Template.Api.Controllers
{
    public class UserController(IUserService service) : BaseController_0<IUserService, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser>(service, service)
    {
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult<BaseResponseApi<OutputUser>>> Authenticate([FromBody] InputAuthenticateUser inputAuthenticateUser)
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
    }
}