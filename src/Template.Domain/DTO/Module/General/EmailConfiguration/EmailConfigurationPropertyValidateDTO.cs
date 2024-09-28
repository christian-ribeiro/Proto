﻿using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.General;

public class EmailConfigurationPropertyValidateDTO : BaseValidateDTO
{
    public EmailConfigurationDTO? OriginalEmailConfigurationDTO { get; private set; }

    public EmailConfigurationPropertyValidateDTO ValidateCreate(EmailConfigurationDTO? originalEmailConfigurationDTO)
    {
        OriginalEmailConfigurationDTO = originalEmailConfigurationDTO;
        return this;
    }

    public EmailConfigurationPropertyValidateDTO ValidateUpdate(EmailConfigurationDTO? originalEmailConfigurationDTO)
    {
        OriginalEmailConfigurationDTO = originalEmailConfigurationDTO;
        return this;
    }

    public EmailConfigurationPropertyValidateDTO ValidateDelete(EmailConfigurationDTO? originalEmailConfigurationDTO)
    {
        OriginalEmailConfigurationDTO = originalEmailConfigurationDTO;
        return this;
    }
}