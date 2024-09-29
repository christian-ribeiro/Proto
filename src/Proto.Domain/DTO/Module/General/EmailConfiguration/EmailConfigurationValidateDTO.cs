using Proto.Arguments.Arguments.Module.General;

namespace Proto.Domain.DTO.Module.General;

public class EmailConfigurationValidateDTO : EmailConfigurationPropertyValidateDTO
{
    public InputCreateEmailConfiguration? InputCreateEmailConfiguration { get; private set; }
    public InputIdentityUpdateEmailConfiguration? InputIdentityUpdateEmailConfiguration { get; private set; }
    public InputIdentityDeleteEmailConfiguration? InputIdentityDeleteEmailConfiguration { get; private set; }

    public EmailConfigurationValidateDTO ValidateCreate(InputCreateEmailConfiguration inputCreateEmailConfiguration, EmailConfigurationDTO? originalEmailConfigurationDTO)
    {
        InputCreateEmailConfiguration = inputCreateEmailConfiguration;
        ValidateCreate(originalEmailConfigurationDTO);
        return this;
    }

    public EmailConfigurationValidateDTO ValidateUpdate(InputIdentityUpdateEmailConfiguration inputIdentityUpdateEmailConfiguration, EmailConfigurationDTO? originalEmailConfigurationDTO)
    {
        InputIdentityUpdateEmailConfiguration = inputIdentityUpdateEmailConfiguration;
        ValidateUpdate(originalEmailConfigurationDTO);
        return this;
    }

    public EmailConfigurationValidateDTO ValidateDelete(InputIdentityDeleteEmailConfiguration inputIdentityDeleteEmailConfiguration, EmailConfigurationDTO? originalEmailConfigurationDTO)
    {
        InputIdentityDeleteEmailConfiguration = inputIdentityDeleteEmailConfiguration;
        ValidateDelete(originalEmailConfigurationDTO);
        return this;
    }
}