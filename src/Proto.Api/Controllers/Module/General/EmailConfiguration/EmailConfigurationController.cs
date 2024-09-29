using Proto.Api.Controllers.Module.Base;
using Proto.Arguments.Arguments.Module.General;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.General;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.General;

public class EmailConfigurationController(IUnitOfWork unitOfWork, IEmailConfigurationService service, IUserService userService) : BaseController_0<IEmailConfigurationService, OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration>(unitOfWork, service, userService) { }