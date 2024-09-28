using Template.Arguments.Arguments.Module.Registration;
using Template.Domain.Interface.Service.Module.Base;

namespace Template.Domain.Interface.Service.Module.Registration;

public interface IUserMenuService : IBaseService_0<OutputUserMenu, InputIdentifierUserMenu, InputCreateUserMenu, InputUpdateUserMenu, InputIdentityUpdateUserMenu, InputIdentityDeleteUserMenu>
{
    List<long> Replace(List<InputReplaceUserMenu> listInputReplaceUserMenu);
}