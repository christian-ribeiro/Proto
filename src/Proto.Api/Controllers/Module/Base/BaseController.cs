using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.General.Session;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Service.Module.Base;
using Proto.Domain.Interface.Service.Module.Registration;

namespace Proto.Api.Controllers.Module.Base;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class BaseController_0<TService, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete>(IUnitOfWork unitOfWork, TService service, IUserService userService) : Controller
        where TService : IBaseService_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
{
    public Guid _guidSessionDataRequest;
    protected readonly TService _service = service;
    protected readonly IUserService _userService = userService;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

        if (!allowAnonymous)
        {
            long userId = Convert.ToInt64(Request.HttpContext.User.FindFirst("UserId")!.Value ?? "0");
            var loggedUser = _userService.Get(userId);
            if (loggedUser != null)
            {
                SetData();
                SessionData.SetLoggedUser(_guidSessionDataRequest, new LoggedUser(loggedUser.Id, loggedUser.Name, loggedUser.Email, loggedUser.Language));
            }
        }

        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        unitOfWork.CommitAsync();
    }

    #region Read
    [HttpGet("{id}")]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> Get([FromRoute] long id)
    {
        try
        {
            TOutput response = _service.Get(id);
            if (response == null)
                return NotFound(new BaseResponseApi<string> { ErrorMessage = "Registro não encontrado" });

            return await ResponseAsync(response);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetByIdentifier")]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetByIdentifier([FromBody] TInputIdentifier inputIdentifier)
    {
        try
        {
            TOutput response = _service.GetByIdentifier(inputIdentifier);
            if (response == null)
                return NotFound(new BaseResponseApi<string> { ErrorMessage = "Registro não encontrado" });

            return await ResponseAsync(response);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpGet]
    public virtual async Task<ActionResult<BaseResponseApi<List<TOutput>>>> GetAll()
    {
        try
        {
            List<TOutput> response = _service.GetAll();
            return await ResponseAsync(response);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetListByListIdentifier")]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetListByListIdentifier([FromBody] List<TInputIdentifier> listInputIdentifier)
    {
        try
        {
            List<TOutput> response = _service.GetListByListIdentifier(listInputIdentifier);
            if (response == null)
                return NotFound(new BaseResponseApi<string> { ErrorMessage = "Registro não encontrado" });

            return await ResponseAsync(response);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetListByListId")]
    [ProducesResponseType<BaseResponseApi<string>>(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetListByListId([FromBody] List<long> listId)
    {
        try
        {
            List<TOutput> response = _service.GetListByListId(listId);
            if (response == null)
                return NotFound(new BaseResponseApi<string> { ErrorMessage = "Registro não encontrado" });

            return await ResponseAsync(response);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Create
    [HttpPost("Create")]
    [ProducesResponseType<BaseResponseApi<List<string>>>(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<BaseResponseApi<long>>> Create([FromBody] TInputCreate inputCreate)
    {
        try
        {
            return await ResponseAsync(_service?.Create(inputCreate), 201);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("Create/Multiple")]
    [ProducesResponseType<BaseResponseApi<List<string>>>(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<BaseResponseApi<List<long>>>> Create([FromBody] List<TInputCreate> listInputCreate)
    {
        try
        {
            return await ResponseAsync(_service?.Create(listInputCreate), 201);
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Update
    [HttpPut("Update")]
    [ProducesResponseType<BaseResponseApi<List<string>>>(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<BaseResponseApi<long>>> Update(TInputIdentityUpdate inputIdentityUpdate)
    {
        try
        {
            return await ResponseAsync(_service.Update(inputIdentityUpdate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPut("Update/Multiple")]
    [ProducesResponseType<BaseResponseApi<List<string>>>(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<BaseResponseApi<List<long>>>> Update([FromBody] List<TInputIdentityUpdate> listInputIdentityUpdate)
    {
        try
        {
            return await ResponseAsync(_service.Update(listInputIdentityUpdate));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Delete
    [HttpDelete("Delete")]
    [ProducesResponseType<BaseResponseApi<List<string>>>(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<BaseResponseApi<bool>>> Delete([FromBody] TInputIdentityDelete inputIdentityDelete)
    {
        try
        {
            return await ResponseAsync(_service?.Delete(inputIdentityDelete));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpDelete("Delete/Multiple")]
    public virtual async Task<ActionResult<BaseResponseApi<bool>>> Delete([FromBody] List<TInputIdentityDelete> listInputIdentityDelete)
    {
        try
        {
            return await ResponseAsync(_service?.Delete(listInputIdentityDelete));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Internal
    [NonAction]
    public async Task<ActionResult> ResponseAsync<ResponseType>(ResponseType result, int statusCode = 0)
    {
        try
        {
            return await Task.FromResult(StatusCode(statusCode == 0 ? 200 : statusCode, new BaseResponseApi<ResponseType> { Result = result }));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(BadRequest(new BaseResponseApi<string> { ErrorMessage = $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}" }));
        }
    }

    [NonAction]
    public async Task<ActionResult> ResponseExceptionAsync(Exception ex)
    {
        return await Task.FromResult(BadRequest(new BaseResponseApi<string> { ErrorMessage = ex.Message }));
    }

    [NonAction]
    public void SetData()
    {
        Guid guidSessionDataRequest = SessionData.Initialize();
        SetGuid(guidSessionDataRequest);
    }

    [NonAction]
    public void SetGuid(Guid guidSessionDataRequest)
    {
        _guidSessionDataRequest = guidSessionDataRequest;
        SessionHelper.SetGuidSessionDataRequest(this, guidSessionDataRequest);
    }

    #endregion
}

public class BaseController_1<TService, TOutput, TInputIdentifier>(IUnitOfWork unitOfWork, TService service, IUserService userService) : BaseController_0<TService, TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0>(unitOfWork, service, userService)
        where TService : IBaseService_1<TOutput, TInputIdentifier>
        where TOutput : BaseOutput<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
{
    #region NotImplemented
    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<long>>> Create([FromBody] BaseInputCreate_0 inputCreate)
    {
        throw new NotImplementedException();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<List<long>>>> Create([FromBody] List<BaseInputCreate_0> listInputCreate)
    {
        throw new NotImplementedException();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<long>>> Update([FromBody] BaseInputIdentityUpdate_0 inputIdentityUpdate)
    {
        throw new NotImplementedException();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<List<long>>>> Update([FromBody] List<BaseInputIdentityUpdate_0> listInputIdentityUpdate)
    {
        throw new NotImplementedException();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<bool>>> Delete([FromBody] BaseInputIdentityDelete_0 inputIdentityDelete)
    {
        throw new NotImplementedException();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public override Task<ActionResult<BaseResponseApi<bool>>> Delete([FromBody] List<BaseInputIdentityDelete_0> listInputIdentityDelete)
    {
        throw new NotImplementedException();
    }
    #endregion
}