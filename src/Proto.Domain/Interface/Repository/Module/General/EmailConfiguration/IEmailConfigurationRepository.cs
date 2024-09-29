using Proto.Arguments.Arguments.Module.General;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.General;
using Proto.Domain.Interface.Repository.Module.Base;

namespace Proto.Domain.Interface.Repository.Module.General;

public interface IEmailConfigurationRepository : IBaseRepository_0<OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>
{
    EmailConfigurationDTO? GetByType(EnumEmailConfigurationType emailConfigurationType);
}