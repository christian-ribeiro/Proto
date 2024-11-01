using Proto.Arguments.Arguments.Module.General;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.General;
using Proto.Domain.Interface.Repository.Module.General;
using Proto.Domain.Interface.Service.Module.General;
using Proto.Domain.Service.Module.Base;

namespace Proto.Domain.Service.Module.General;

public class EmailConfigurationService(IEmailConfigurationRepository repository) : BaseService_0_1<IEmailConfigurationRepository, OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, EmailConfigurationValidateDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>(repository), IEmailConfigurationService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<EmailConfigurationValidateDTO> listEmailConfigurationValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where i.OriginalEmailConfigurationDTO != null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listEmailConfigurationValidateDTO.IndexOf(i), "Já existe um registro com esse identificador")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where i.InputCreateEmailConfiguration == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listEmailConfigurationValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateEmailConfiguration?.Server)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Servidor deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateEmailConfiguration?.DisplayName)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Nome de exibição deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateEmailConfiguration?.FromEmail)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Remetente deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateEmailConfiguration?.Username)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Usuário deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputCreateEmailConfiguration?.Password)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Senha deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(0, 100, i.InputCreateEmailConfiguration?.EmailCopy)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "E-mail de cópia deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidEmail(i.InputCreateEmailConfiguration?.FromEmail)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Informe um e-mail válido")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where !string.IsNullOrEmpty(i.InputCreateEmailConfiguration?.EmailCopy) && InvalidEmail(i.InputCreateEmailConfiguration?.EmailCopy)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(new InputIdentifierEmailConfiguration(i.InputCreateEmailConfiguration!.FromEmail, i.InputCreateEmailConfiguration!.EmailConfigurationType), "Informe um e-mail válido")).ToList();

                break;
            case EnumProcessType.Update:
                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where i.OriginalEmailConfigurationDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listEmailConfigurationValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where i.InputIdentityUpdateEmailConfiguration?.InputUpdate == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listEmailConfigurationValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.Server)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Servidor deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.DisplayName)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Nome de exibição deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.FromEmail)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Remetente deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.Username)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Usuário deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(1, 100, i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.Password)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Senha deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidLength(0, 100, i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.EmailCopy)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "E-mail de cópia deve ter entre 1 e 100 caracteres")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where InvalidEmail(i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.FromEmail)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Informe um e-mail válido")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where !string.IsNullOrEmpty(i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.EmailCopy) && InvalidEmail(i.InputIdentityUpdateEmailConfiguration?.InputUpdate?.EmailCopy)
                     let setInvalid = i.SetInvalid()
                     select AddNotification(i.InputIdentityUpdateEmailConfiguration!.Id, new InputIdentifierEmailConfiguration(i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.FromEmail, i.OriginalEmailConfigurationDTO!.ExternalPropertiesDTO.EmailConfigurationType), "Informe um e-mail válido")).ToList();

                break;
            case EnumProcessType.Delete:

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where i.OriginalEmailConfigurationDTO == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listEmailConfigurationValidateDTO.IndexOf(i), "Registro não encontrado")).ToList();

                _ = (from i in GetListValidDTO(listEmailConfigurationValidateDTO)
                     where i.InputIdentityDeleteEmailConfiguration == null
                     let setInvalid = i.SetInvalid()
                     select AddNotification(listEmailConfigurationValidateDTO.IndexOf(i), "Informe os dados corretamente")).ToList();

                break;
        }
        return true;
    }
    #endregion

    #region Create
    public override List<long> Create(List<InputCreateEmailConfiguration> listInputCreateEmailConfiguration)
    {
        List<EmailConfigurationDTO> listOriginalEmailConfigurationDTO = _repository.GetListByListIdentifier((from i in listInputCreateEmailConfiguration select new InputIdentifierEmailConfiguration(i.FromEmail, i.EmailConfigurationType)).ToList(), getOnlyPrincipal: true);

        var listCreate = (from i in listInputCreateEmailConfiguration
                          let originalEmailConfigurationDTO = (from j in listOriginalEmailConfigurationDTO where j.ExternalPropertiesDTO.FromEmail == i.FromEmail && j.ExternalPropertiesDTO.EmailConfigurationType == i.EmailConfigurationType select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputCreateEmailConfiguration.IndexOf(i),
                              InputCreateEmailConfiguration = i,
                              OriginalEmailConfigurationDTO = originalEmailConfigurationDTO
                          }).ToList();

        List<EmailConfigurationValidateDTO> listEmailConfigurationValidateDTO = (from i in listCreate select new EmailConfigurationValidateDTO().ValidateCreate(i.InputCreateEmailConfiguration, i.OriginalEmailConfigurationDTO)).ToList();
        CanExecuteProcess(listEmailConfigurationValidateDTO, EnumProcessType.Create);
        if (!HasValidItem(listEmailConfigurationValidateDTO))
            return [];


        List<EmailConfigurationDTO> listCreateEmailConfiguration = (from i in GetListValidDTO(listEmailConfigurationValidateDTO) select new EmailConfigurationDTO().Create(_guidSessionDataRequest, i.InputCreateEmailConfiguration!)).ToList();
        return _repository.Create(listCreateEmailConfiguration);
    }
    #endregion

    #region Update
    public override List<long> Update(List<InputIdentityUpdateEmailConfiguration> listInputIdentityUpdateEmailConfiguration)
    {
        List<EmailConfigurationDTO> listOriginalEmailConfigurationDTO = _repository.GetListByListId((from i in listInputIdentityUpdateEmailConfiguration select i.Id).ToList(), true);

        var listUpdate = (from i in listInputIdentityUpdateEmailConfiguration
                          let originalEmailConfigurationDTO = (from j in listOriginalEmailConfigurationDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityUpdateEmailConfiguration.IndexOf(i),
                              InputIdentityUpdateEmailConfiguration = i,
                              OriginalEmailConfigurationDTO = originalEmailConfigurationDTO
                          }).ToList();

        List<EmailConfigurationValidateDTO> listEmailConfigurationValidateDTO = (from i in listUpdate select new EmailConfigurationValidateDTO().ValidateUpdate(i.InputIdentityUpdateEmailConfiguration, i.OriginalEmailConfigurationDTO)).ToList();
        CanExecuteProcess(listEmailConfigurationValidateDTO, EnumProcessType.Update);
        if (!HasValidItem(listEmailConfigurationValidateDTO))
            return [];

        List<EmailConfigurationDTO> listUpdateEmailConfiguration = (from i in GetListValidDTO(listEmailConfigurationValidateDTO) select new EmailConfigurationDTO().Update(_guidSessionDataRequest, i.InputIdentityUpdateEmailConfiguration!.InputUpdate!, i.OriginalEmailConfigurationDTO!.InternalPropertiesDTO)).ToList();
        return _repository.Update(listUpdateEmailConfiguration);
    }
    #endregion

    #region Delete
    public override bool Delete(List<InputIdentityDeleteEmailConfiguration> listInputIdentityDeleteEmailConfiguration)
    {
        List<EmailConfigurationDTO> listOriginalEmailConfigurationDTO = _repository.GetListByListId((from i in listInputIdentityDeleteEmailConfiguration select i.Id).ToList(), true);

        var listDelete = (from i in listInputIdentityDeleteEmailConfiguration
                          let originalEmailConfigurationDTO = (from j in listOriginalEmailConfigurationDTO where j.InternalPropertiesDTO.Id == i.Id select j).FirstOrDefault()
                          select new
                          {
                              Index = listInputIdentityDeleteEmailConfiguration.IndexOf(i),
                              InputIdentityDeleteEmailConfiguration = i,
                              OriginalEmailConfigurationDTO = originalEmailConfigurationDTO
                          }).ToList();

        List<EmailConfigurationValidateDTO> listEmailConfigurationValidateDTO = (from i in listDelete select new EmailConfigurationValidateDTO().ValidateDelete(i.InputIdentityDeleteEmailConfiguration, i.OriginalEmailConfigurationDTO)).ToList();
        CanExecuteProcess(listEmailConfigurationValidateDTO, EnumProcessType.Delete);
        if (!HasValidItem(listEmailConfigurationValidateDTO))
            return false;


        List<EmailConfigurationDTO> listUpdateEmailConfiguration = (from i in GetListValidDTO(listEmailConfigurationValidateDTO) select i.OriginalEmailConfigurationDTO).ToList();
        return _repository.Delete(listUpdateEmailConfiguration);
    }
    #endregion
    #endregion
}