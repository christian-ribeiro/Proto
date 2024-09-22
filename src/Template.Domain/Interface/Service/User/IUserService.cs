using Template.Arguments.Arguments;
using Template.Domain.Interface.Service.Base;

namespace Template.Domain.Interface.Service;

public interface IUserService : IBaseService_0<OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser>
{
    OutputAuthenticateUser Authenticate(InputAuthenticateUser inputAuthenticateUser);
}