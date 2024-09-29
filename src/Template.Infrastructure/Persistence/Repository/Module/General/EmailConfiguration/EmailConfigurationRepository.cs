using Microsoft.EntityFrameworkCore;
using Template.Arguments.Arguments.Module.General;
using Template.Arguments.Enum;
using Template.Domain.DTO.Module.General;
using Template.Domain.Interface.Repository.Module.General;
using Template.Infrastructure.Persistence.Context;
using Template.Infrastructure.Persistence.Entity.Module.General;
using Template.Infrastructure.Persistence.Repository.Module.Base;

namespace Template.Infrastructure.Persistence.Repository.Module.General;

public class EmailConfigurationRepository(AppDbContext context) : BaseRepository_0<AppDbContext, EmailConfiguration, OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration, EmailConfigurationDTO, InternalPropertiesEmailConfigurationDTO, ExternalPropertiesEmailConfigurationDTO, AuxiliaryPropertiesEmailConfigurationDTO>(context), IEmailConfigurationRepository
{
    public EmailConfigurationDTO? GetByType(EnumEmailConfigurationType emailConfigurationType)
    {
        return FromEntityToDTO(_context.EmailConfiguration.AsNoTracking().Where(x => x.EmailConfigurationType == emailConfigurationType).FirstOrDefault()!);
    }
}