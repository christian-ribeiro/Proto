using Proto.Arguments.Arguments.Module.Registration;
using Proto.Arguments.Enum;
using Proto.Arguments.General.Session;
using Proto.Domain.DTO.Module.General;
using Proto.Domain.DTO.Module.Registration;
using Proto.Domain.Extension;
using Proto.Domain.Interface.Repository.Module.General;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Domain.Interface.Service.Module.Registration;
using Proto.Domain.Service.Module.Base;
using Proto.Security.Hashing;
using Proto.Utilities.Interface.Service;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Proto.Domain.Service.Module.Registration;

public class UserService(IUserRepository repository, IEmailService emailService, IEmailConfigurationRepository emailConfigurationRepository) : BaseService_0_1<IUserRepository, OutputUser, InputIdentifierUser, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDeleteUser, UserDTO, UserValidateDTO, InternalPropertiesUserDTO, ExternalPropertiesUserDTO, AuxiliaryPropertiesUserDTO>(repository), IUserService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<UserValidateDTO> listUserValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO != null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listUserValidateDTO.IndexOf(i), "Já existe um registro com esse identificador")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.InputCreateUser == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listUserValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 6, i.InputCreateUser?.Code)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierUser(i.InputCreateUser!.Email), "Código deve ter entre 1 e 6 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateUser?.Name)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierUser(i.InputCreateUser!.Email), "Nome deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(6, 100, i.InputCreateUser?.Password)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierUser(i.InputCreateUser!.Email), "Senha deve ter entre 6 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateUser?.Email)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierUser(i.InputCreateUser!.Email), "E-mail deve ter entre 1 e 6 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidEmail(i.InputCreateUser?.Email)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierUser(i.InputCreateUser!.Email), "Informe um e-mail válido")).ToList();

                break;
            case EnumProcessType.Update:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listUserValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.InputIdentityUpdateUser?.InputUpdate == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listUserValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateUser?.InputUpdate?.Name)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateUser!.Id, new InputIdentifierUser(i.OriginalUserDTO!.ExternalPropertiesDTO.Email), "Nome deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateUser?.InputUpdate?.Email)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateUser!.Id, new InputIdentifierUser(i.OriginalUserDTO!.ExternalPropertiesDTO.Email), "E-mail deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where InvalidEmail(i.InputIdentityUpdateUser?.InputUpdate?.Email)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateUser!.Id, new InputIdentifierUser(i.OriginalUserDTO!.ExternalPropertiesDTO.Email), "Informe um e-mail válido")).ToList();

                break;
            case EnumProcessType.Delete:
                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.OriginalUserDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listUserValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listUserValidateDTO)
                     where i.InputIdentityDeleteUser == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listUserValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                break;
        }

        return true;
    }
    #endregion

    #region Create
    public override List<long> Create(List<InputCreateUser> listInputCreateUser)
    {
        List<UserDTO> listOriginalUserDTO = _repository.GetListByListIdentifier((from i in listInputCreateUser select new InputIdentifierUser(i.Email)).ToList(), true);

        var listCreate = (from i in listInputCreateUser
                          let originalUserDTO = (from j in listOriginalUserDTO where j.ExternalPropertiesDTO.Email == i.Email select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateUser.IndexOf(i),
                              InputCreateUser = i,
                              OriginalUserDTO = originalUserDTO
                          }).ToList();

        List<UserValidateDTO> listUserValidateDTO = (from i in listCreate select new UserValidateDTO().ValidateCreate(i.InputCreateUser, i.OriginalUserDTO)).ToList();

        CanExecuteProcess(listUserValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listUserValidateDTO))
            return [];

        List<UserDTO> listCreateUser = (from i in GetListValidDTO(listUserValidateDTO) select new UserDTO().Create(_guidSessionDataRequest, new ExternalPropertiesUserDTO(i.InputCreateUser!.Code, i.InputCreateUser!.Name, EncryptService.Encrypt(i.InputCreateUser!.Password), i.InputCreateUser!.Email, EnumLanguage.Portuguese))).ToList();
        return _repository.Create(listCreateUser);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateUser> listInputIdentityUpdateUser)
    {
        List<UserDTO> listOriginalUserDTO = _repository.GetListByListId((from i in listInputIdentityUpdateUser select i.Id).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateUser
                          let originalUserDTO = (from j in listOriginalUserDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateUser.IndexOf(i),
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
    public override bool Delete(List<InputIdentityDeleteUser> listInputIdentityDeleteUser)
    {
        List<UserDTO> listOriginalUserDTO = _repository.GetListByListId((from i in listInputIdentityDeleteUser select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDeleteUser
                          let originalUserDTO = (from j in listOriginalUserDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDeleteUser.IndexOf(i),
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

        if (!inputAuthenticateUser.Password.CompareHash(userDTO.ExternalPropertiesDTO.Password))
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

    public async Task<bool> SendEmailForgotPassword(InputSendEmailForgotPasswordUser inputSendEmailForgotPasswordUser)
    {
        UserDTO originalUserDTO = _repository.GetByIdentifier(new InputIdentifierUser(inputSendEmailForgotPasswordUser.Email), true);

        if (originalUserDTO != null)
        {
            byte[] randomBytes = new byte[4];
            RandomNumberGenerator.Fill(randomBytes);
            string recoveryCode = (Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % 1000000).ToString("D6");

            originalUserDTO.InternalPropertiesDTO.SetProperty(nameof(originalUserDTO.InternalPropertiesDTO.PasswordRecoveryCode), recoveryCode);
            _repository.Update(originalUserDTO);

            string htmlProto = File.ReadAllText("wwwroot/html-template/recovery-password.html");
            string userEncoded = WebUtility.HtmlEncode(originalUserDTO.ExternalPropertiesDTO.Name);

            htmlProto = htmlProto.Replace("{{USER}}", userEncoded);
            htmlProto = htmlProto.Replace("{{CODE}}", recoveryCode);

            EmailConfigurationDTO emailConfigurationDTO = emailConfigurationRepository.GetByType(EnumEmailConfigurationType.RecoveryPassword)!;
            await emailService.SendEmailAsync(inputSendEmailForgotPasswordUser.Email, "Esqueci a Senha", htmlProto, true, emailConfigurationDTO);
        }

        return await Task.FromResult(true);
    }

    public bool RedefinePasswordForgotPassword(InputRedefinePasswordForgotPasswordUser inputRedefinePasswordForgotPasswordUser)
    {
        UserDTO? originalUserDTO = _repository.GetByPasswordRecoveryCode(inputRedefinePasswordForgotPasswordUser.PasswordRecoveryCode);

        if (originalUserDTO != null)
        {
            originalUserDTO.ExternalPropertiesDTO.SetProperty(nameof(originalUserDTO.ExternalPropertiesDTO.Password), EncryptService.Encrypt(inputRedefinePasswordForgotPasswordUser.NewPassword));
            originalUserDTO.InternalPropertiesDTO.SetProperty<string>(nameof(originalUserDTO.InternalPropertiesDTO.PasswordRecoveryCode), null);
            _repository.Update(originalUserDTO);
        }

        return true;
    }

    public bool RedefinePassword(InputRedefinePasswordUser inputRedefinePasswordUser)
    {
        long loggedUserId = SessionData.GetLoggedUser(_guidSessionDataRequest)!.Id;

        UserDTO? originalUserDTO = _repository.Get(loggedUserId, true);

        if (originalUserDTO != null)
        {
            if (!inputRedefinePasswordUser.CurrentPassword.CompareHash(originalUserDTO.ExternalPropertiesDTO.Password))
                throw new Exception("Senha inválida");

            if (!inputRedefinePasswordUser.CurrentPassword.CompareHash(originalUserDTO.ExternalPropertiesDTO.Password) || string.IsNullOrEmpty(inputRedefinePasswordUser.NewPassword) || inputRedefinePasswordUser.NewPassword != inputRedefinePasswordUser.ConfirmNewPassword)
                throw new Exception("Senhas não conferem");

            originalUserDTO.ExternalPropertiesDTO.SetProperty(nameof(originalUserDTO.ExternalPropertiesDTO.Password), EncryptService.Encrypt(inputRedefinePasswordUser.NewPassword));
            _repository.Update(originalUserDTO);
        }

        return true;
    }
    #endregion
}