using Template.Arguments.Arguments.Module.General;
using Template.Arguments.General;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.General;

public class EmailConfigurationDTO : BaseDTO_0<OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>
{
    public static implicit operator SmtpConfiguration?(EmailConfigurationDTO dto)
    {
        return dto == null ? default : new SmtpConfiguration(dto.ExternalPropertiesDTO.Server, dto.ExternalPropertiesDTO.Port, dto.ExternalPropertiesDTO.DisplayName, dto.ExternalPropertiesDTO.FromEmail, dto.ExternalPropertiesDTO.Username, dto.ExternalPropertiesDTO.Password, dto.ExternalPropertiesDTO.Ssl, dto.ExternalPropertiesDTO.EmailCopy);
    }
}