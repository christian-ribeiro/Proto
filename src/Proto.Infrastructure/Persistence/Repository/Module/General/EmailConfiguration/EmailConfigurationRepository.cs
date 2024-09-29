using Microsoft.EntityFrameworkCore;
using Proto.Arguments.Arguments.Module.General;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.General;
using Proto.Domain.Interface.Repository.Module.General;
using Proto.Infrastructure.Persistence.Context;
using Proto.Infrastructure.Persistence.Entity.Module.General;
using Proto.Infrastructure.Persistence.Repository.Module.Base;

namespace Proto.Infrastructure.Persistence.Repository.Module.General;

public class EmailConfigurationRepository(AppDbContext context) : BaseRepository_0<AppDbContext, EmailConfiguration, OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>(context), IEmailConfigurationRepository
{
    public EmailConfigurationDTO? GetByType(EnumEmailConfigurationType emailConfigurationType)
    {
        return FromEntityToDTO(_context.EmailConfiguration.AsNoTracking().Where(x => x.EmailConfigurationType == emailConfigurationType).FirstOrDefault()!);
    }
}