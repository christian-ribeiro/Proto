﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Template.Arguments.Arguments.Base;
using Template.Arguments.General.Session;
using Template.Domain.Interface;
using Template.Domain.Interface.Service;
using Template.Domain.Interface.Service.Base;

namespace Template.Api.Controllers.Base;

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
                SessionData.SetLoggedUser(_guidSessionDataRequest, new LoggedUser(loggedUser.Id, loggedUser.Name, loggedUser.Email));
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
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> Get(long id)
    {
        try
        {
            return await ResponseAsync(_service.Get(id));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetByIdentifier")]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service.GetByIdentifier(inputIdentifier));
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
            return await ResponseAsync(_service.GetAll());
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetListByListIdentifier")]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier)
    {
        try
        {
            return await ResponseAsync(_service.GetListByListIdentifier(listInputIdentifier));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }

    [HttpPost("GetListByListId")]
    public virtual async Task<ActionResult<BaseResponseApi<TOutput>>> GetListByListId(List<long> listId)
    {
        try
        {
            return await ResponseAsync(_service.GetListByListId(listId));
        }
        catch (Exception ex)
        {
            return await ResponseExceptionAsync(ex);
        }
    }
    #endregion

    #region Create
    [HttpPost("Create")]
    public virtual async Task<ActionResult<BaseResponseApi<long>>> Create(TInputCreate inputCreate)
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
    public virtual async Task<ActionResult<BaseResponseApi<List<long>>>> Create(List<TInputCreate> listInputCreate)
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
    public virtual async Task<ActionResult<BaseResponseApi<List<long>>>> Update(List<TInputIdentityUpdate> listInputIdentityUpdate)
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
    public virtual async Task<ActionResult<BaseResponseApi<bool>>> Delete(TInputIdentityDelete inputIdentityDelete)
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
    public virtual async Task<ActionResult<BaseResponseApi<bool>>> Delete(List<TInputIdentityDelete> listInputIdentityDelete)
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