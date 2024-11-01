using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface.Service.Module.Base;

namespace Proto.Domain.Interface.Service.Module.Registration;

public interface IUserService : IBaseService_0_1<OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser>
{
    OutputAuthenticateUser Authenticate(InputAuthenticateUser inputAuthenticateUser);
    OutputAuthenticateUser RefreshToken(InputRefreshTokenUser inputRefreshTokenUser);
    Task<bool> SendEmailForgotPassword(InputSendEmailForgotPasswordUser inputRedefinePasswordForgotPasswordUser);
    bool RedefinePasswordForgotPassword(InputRedefinePasswordForgotPasswordUser inputRedefinePasswordForgotPasswordUser);
    bool RedefinePassword(InputRedefinePasswordUser inputRedefinePasswordUser);
}