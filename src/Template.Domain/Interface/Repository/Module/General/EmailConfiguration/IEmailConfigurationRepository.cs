using Template.Arguments.Arguments.Module.General;
using Template.Arguments.Enum;
using Template.Domain.DTO.Module.General;
using Template.Domain.Interface.Repository.Module.Base;

namespace Template.Domain.Interface.Repository.Module.General;

public interface IEmailConfigurationRepository : IBaseRepository_0<OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>
{
    EmailConfigurationDTO? GetByType(EnumEmailConfigurationType emailConfigurationType);
}