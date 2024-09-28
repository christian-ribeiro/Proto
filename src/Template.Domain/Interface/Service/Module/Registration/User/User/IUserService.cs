using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface.Service.Module.Base;

namespace Template.Domain.Interface.Service.Module.Registration;

public interface IUserService : IBaseService_0<OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser>
{
    OutputAuthenticateUser Authenticate(InputAuthenticateUser inputAuthenticateUser);
    OutputAuthenticateUser RefreshToken(InputRefreshTokenUser inputRefreshTokenUser);
}