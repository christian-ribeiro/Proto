using Proto.Arguments.Arguments.Module.Registration;
using Proto.Domain.Interface.Service.Module.Base;

namespace Proto.Domain.Interface.Service.Module.Registration;

public interface IUserMenuService : IBaseService_0_1<OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu>
{
    List<long> Replace(List<InputReplaceUserMenu> listInputReplaceUserMenu);
}