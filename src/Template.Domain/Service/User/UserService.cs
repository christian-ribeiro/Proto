using System.Security.Claims;
using Template.Arguments.Arguments;
using Template.Arguments.Enum;
using Template.Domain.DTO;
using Template.Domain.Extension;
using Template.Domain.Interface.Repository;
using Template.Domain.Interface.Service;
using Template.Domain.Service.Base;
using Template.Security.Hashing;

namespace Template.Domain.Service;

public class UserService(IUserRepository repository) : BaseService_0<IUserRepository, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, UserValidateDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO>(repository), IUserService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<UserValidateDTO> listUserValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            #region Create
            case EnumProcessType.Create:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO != null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 6, i.InputCreateUser?.Code)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateUser?.Name)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateUser?.Password)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateUser?.Email)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();
                break;
            #endregion
            #region Update
            case EnumProcessType.Update:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateUser?.InputUpdate?.Name)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateUser?.InputUpdate?.Email)
                     let setInvalid = i.SetInvalid()
                     select true).ToList();
                break;
            #endregion
            #region Delete
            case EnumProcessType.Delete:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();
                break;
            #endregion
            #region View
            case EnumProcessType.View:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO == null
                     let setInvalid = i.SetInvalid()
                     select true).ToList();
                break;
                #endregion
        }

        return true;
    }
    #endregion

    #region Create
    public override List<long> Create(List<InputCreateUser> listInputCreate)
    {
        List<UserDTO> listOriginalUser = _repository.GetListByListIdentifier((from i in listInputCreate select new InputIdentifierUser(i.Email)).ToList(), true);

        var listCreate = (from i in listInputCreate
                          let originalUserDTO = (from j in listOriginalUser where j.ExternalPropertiesDTO.Email == i.Email select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreate.IndexOf(i),
                              InputCreateUser = i,
                              OriginalUserDTO = originalUserDTO
                          }).ToList();

        List<UserValidateDTO> listUserValidateDTO = (from i in listCreate select new UserValidateDTO().ValidateCreate(i.InputCreateUser, i.OriginalUserDTO)).ToList();

        CanExecuteProcess(listUserValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listUserValidateDTO))
            return [];

        List<UserDTO> listCreasteUser = (from i in GetListValidDTO(listUserValidateDTO) select new UserDTO().Create(_guidSessionDataRequest, i.InputCreateUser!)).ToList();
        return _repository.Create(listCreasteUser);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateUser> listInputIdentityUpdate)
    {
        List<UserDTO> listOriginalUser = _repository.GetListByListId((from i in listInputIdentityUpdate select i.Id).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdate
                          let originalUserDTO = (from j in listOriginalUser where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdate.IndexOf(i),
                              InputIdentityUpdateUser = i,
                              OriginalUserDTO = originalUserDTO
                          }).ToList();

        List<UserValidateDTO> listUserValidateDTO = (from i in listUpdate select new UserValidateDTO().ValidateUpdate(i.InputIdentityUpdateUser, i.OriginalUserDTO)).ToList();
        CanExecuteProcess(listUserValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listUserValidateDTO))
            return [];

        List<UserDTO> listUpdateUser = (from i in GetListValidDTO(listUserValidateDTO) select new UserDTO().Update(_guidSessionDataRequest, new ExternalPropertiesUserDTO(i.OriginalUserDTO!.ExternalPropertiesDTO.Code, i.InputIdentityUpdateUser!.InputUpdate!.Name, i.OriginalUserDTO.ExternalPropertiesDTO.Password, i.InputIdentityUpdateUser.InputUpdate.Email, i.OriginalUserDTO.ExternalPropertiesDTO.Language), i.OriginalUserDTO.InternalPropertiesDTO)).ToList();
        return _repository.Update(listUpdateUser);
    }
    #endregion

    #region Delete
    public override bool Delete(List<InputIdentityDeleteUser> listInputIdentityDelete)
    {
        List<UserDTO> listOriginalUser = _repository.GetListByListId((from i in listInputIdentityDelete select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDelete
                          let originalUserDTO = (from j in listOriginalUser where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDelete.IndexOf(i),
                              InputIdentityDeleteUser = i,
                              OriginalUserDTO = originalUserDTO
                          }).ToList();

        List<UserValidateDTO> listUserValidateDTO = (from i in listDelete select new UserValidateDTO().ValidateDelete(i.InputIdentityDeleteUser, i.OriginalUserDTO)).ToList();
        CanExecuteProcess(listUserValidateDTO, EnumProcessType.Delete);
        if (!HasValidItem(listUserValidateDTO))
            return false;


        List<UserDTO> listUpdateUser = (from i in GetListValidDTO(listUserValidateDTO) select i.OriginalUserDTO).ToList();
        return _repository.Delete(listUpdateUser);
    }
    #endregion
    #endregion

    #region Custom
    public OutputAuthenticateUser Authenticate(InputAuthenticateUser inputAuthenticateUser)
    {
        UserDTO userDTO = _repository.GetByIdentifier(new InputIdentifierUser(inputAuthenticateUser.Email));

        if (!EncryptService.CompareHash(inputAuthenticateUser.Password, userDTO.ExternalPropertiesDTO.Password))
            throw new Exception("Senha inválida");

        string refreshToken = JwtExtension.GenerateRefreshToken();

        userDTO.InternalPropertiesDTO.SetProperty(nameof(userDTO.InternalPropertiesDTO.LoginKey), Guid.NewGuid());
        userDTO.InternalPropertiesDTO.SetProperty(nameof(userDTO.InternalPropertiesDTO.RefreshToken), refreshToken);

        OutputUser user = FromDTOToOutput(userDTO);

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

        return new OutputAuthenticateUser(token, refreshToken, FromDTOToOutput(originalUserDTO));
    }
    #endregion
}