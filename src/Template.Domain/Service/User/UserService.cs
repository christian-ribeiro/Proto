using Template.Arguments.Arguments;
using Template.Domain.DTO;
using Template.Domain.Interface.Repository;
using Template.Domain.Interface.Service;
using Template.Domain.Service.Base;

namespace Template.Domain.Service
{
    public class UserService(IUserRepository repository) : BaseService_0<IUserRepository, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO>(repository), IUserService
    {
        public OutputUser Authenticate(InputAuthenticateUser inputAuthenticateUser)
        {
            UserDTO userDTO = _repository.GetByIdentifier(new InputIdentifierUser(inputAuthenticateUser.Email));
            return new OutputUser("", "", "", "", Arguments.Enum.EnumLanguage.Portuguese);
        }
    }
}