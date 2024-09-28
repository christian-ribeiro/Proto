using Template.Api.Controllers.Module.Base;
using Template.Arguments.Arguments.Module.General;
using Template.Domain.Interface;
using Template.Domain.Interface.Service.Module;
using Template.Domain.Interface.Service.Module.Registration;

namespace Template.Api.Controllers.Module.General;

public class EmailConfigurationController(IUnitOfWork unitOfWork, IEmailConfigurationService service, IUserService userService) : BaseController_0<IEmailConfigurationService, OutputEmailConfiguration, InputIdentifierEmailConfiguration, InputCreateEmailConfiguration, InputUpdateEmailConfiguration, InputIdentityUpdateEmailConfiguration, InputIdentityDeleteEmailConfiguration>(unitOfWork, service, userService) { }