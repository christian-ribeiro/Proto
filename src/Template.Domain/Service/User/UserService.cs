using Template.Arguments.Arguments;
using Template.Arguments.General.Session;
using Template.Domain.DTO;
using Template.Domain.Extension;
using Template.Domain.Interface.Repository;
using Template.Domain.Interface.Service;
using Template.Domain.Service.Base;

namespace Template.Domain.Service;

public class UserService(IUserRepository repository) : BaseService_0<IUserRepository, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO>(repository), IUserService
{
    public OutputAuthenticateUser Authenticate(InputAuthenticateUser inputAuthenticateUser)
    {
        UserDTO userDTO = _repository.GetByIdentifier(new InputIdentifierUser(inputAuthenticateUser.Email));
        userDTO.InternalPropertiesDTO.SetProperty(nameof(userDTO.InternalPropertiesDTO.LoginKey), Guid.NewGuid());
        userDTO.InternalPropertiesDTO.SetProperty(nameof(userDTO.InternalPropertiesDTO.RefreshToken), JwtExtension.GenerateRefreshToken());

        OutputUser user = SessionData.Mapper!.MapperDTOOutput.Map<UserDTO, OutputUser>(userDTO);
        _repository.Update(userDTO);
        string token = JwtExtension.GenerateJwtToken(user);

        return new OutputAuthenticateUser(token, user);
    }
}