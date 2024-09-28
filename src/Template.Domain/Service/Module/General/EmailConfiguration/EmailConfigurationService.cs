using Template.Arguments.Arguments.Module.General;
using Template.Arguments.Enum;
using Template.Domain.DTO.Module.General;
using Template.Domain.Interface.Repository.Module.General;
using Template.Domain.Interface.Service.Module.General;
using Template.Domain.Service.Module.Base;

namespace Template.Domain.Service.Module.General;

public class EmailConfigurationService(IEmailConfigurationRepository repository) : BaseService_0<IEmailConfigurationRepository, OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, EmailConfigurationValidateDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>(repository), IEmailConfigurationService
{
    #region Base
    #region Validate
    public override bool CanExecuteProcess(List<EmailConfigurationValidateDTO> listEmailConfigurationValidateDTO, EnumProcessType processType)
    {
        switch (processType)
        {
            case EnumProcessType.Create:
                break;
            case EnumProcessType.Update:
                break;
            case EnumProcessType.Delete:
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