using System.Security.Claims;
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
        string refreshToken = JwtExtension.GenerateRefreshToken();

        userDTO.InternalPropertiesDTO.SetProperty(nameof(userDTO.InternalPropertiesDTO.LoginKey), Guid.NewGuid());
        userDTO.InternalPropertiesDTO.SetProperty(nameof(userDTO.InternalPropertiesDTO.RefreshToken), refreshToken);

        OutputUser user = SessionData.Mapper!.MapperDTOOutput.Map<UserDTO, OutputUser>(userDTO);
        _repository.Update(userDTO);
        string token = JwtExtension.GenerateJwtToken(user);

        return new OutputAuthenticateUser(token, refreshToken, user);
    }

    public OutputAuthenticateUser RefreshToken(InputRefreshTokenUser inputRefreshTokenUser)
    {
        ClaimsPrincipal principal = JwtExtension.GetPrincipalFromExpiredToken(inputRefreshTokenUser.Token);
        long userId = Convert.ToInt64(principal.FindFirst("UserId")!.Value);

        UserDTO originalUserDTO = _repository.Get(userId);

        if (originalUserDTO == null)
            throw new ArgumentNullException("Usuário ou senha inválidos");

        if (originalUserDTO.InternalPropertiesDTO.RefreshToken != inputRefreshTokenUser.RefreshToken)
            throw new InvalidOperationException("Refresh Token Inválido");

        string token = JwtExtension.GenerateJwtToken(principal.Claims.ToList());
        string refreshToken = JwtExtension.GenerateRefreshToken();

        originalUserDTO.InternalPropertiesDTO.SetProperty(nameof(originalUserDTO.InternalPropertiesDTO.RefreshToken), refreshToken);

        _repository.Update(originalUserDTO);

        return new OutputAuthenticateUser(token, refreshToken, SessionData.Mapper!.MapperDTOOutput.Map<UserDTO, OutputUser>(originalUserDTO));
    }
}