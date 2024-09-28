using System.Text.RegularExpressions;
using Template.Arguments.Arguments.Module.Base;
using Template.Arguments.Enum;
using Template.Arguments.General.Session;
using Template.Domain.DTO.Module.Base;
using Template.Domain.Interface.Repository.Module.Base;
using Template.Domain.Interface.Service.Module.Base;

namespace Template.Domain.Service.Module.Base;

public class BaseService_0<TRepository, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TValidateDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>(TRepository repository) : IBaseService_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete>
        where TRepository : IBaseRepository_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TOutput : BaseOutput<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TDTO : BaseDTO_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>, new()
        where TValidateDTO : BaseValidateDTO
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
{
    public Guid _guidSessionDataRequest;
    protected readonly TRepository _repository = repository;

    #region Validate
    public virtual bool CanExecuteProcess(List<TValidateDTO> listValidateDTO, EnumProcessType processType)
    {
        throw new NotImplementedException();
    }

    public List<TValidateDTO> GetListValidDTO(List<TValidateDTO> listValidateDTO)
    {
        return (from i in listValidateDTO where !i.Invalid select i).ToList();
    }

    public bool HasValidItem(List<TValidateDTO> listValidateDTO)
    {
        return (from i in listValidateDTO where !i.Invalid select i).Any();
    }

    public bool InvalidLength(int minLength, int maxLength, string? value)
    {
        return value?.Length < minLength || value?.Length > maxLength;
    }

    public bool InvalidEmail(string? value)
    {
        Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        if (string.IsNullOrWhiteSpace(value))
            return false;

        return !EmailRegex.IsMatch(value);
    }
    #endregion

    #region Read
    public virtual TOutput Get(long id)
    {
        return FromDTOToOutput(_repository.Get(id));
    }

    public virtual TOutput GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        return FromDTOToOutput(_repository.GetByIdentifier(inputIdentifier)!);
    }

    public virtual List<TOutput> GetAll()
    {
        return FromDTOToOutput(_repository.GetAll());
    }

    public virtual List<TOutput> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier)
    {
        return FromDTOToOutput(_repository.GetListByListIdentifier(listInputIdentifier));
    }

    public virtual List<TOutput> GetListByListId(List<long> listId)
    {
        return FromDTOToOutput(_repository.GetListByListId(listId));
    }
    #endregion

    #region Create
    public long Create(TInputCreate inputCreate)
    {
        return Create([inputCreate]).FirstOrDefault();
    }

    public virtual List<long> Create(List<TInputCreate> listInputCreate)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Update
    public long Update(TInputIdentityUpdate inputIdentityUpdate)
    {
        return Update([inputIdentityUpdate]).FirstOrDefault();
    }

    public virtual List<long> Update(List<TInputIdentityUpdate> listInputIdentityUpdate)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Delete
    public bool Delete(TInputIdentityDelete inputIdentityDelete)
    {
        return Delete([inputIdentityDelete]);
    }

    public virtual bool Delete(List<TInputIdentityDelete> listInputIdentityDelete)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Custom
    internal static TOutput FromDTOToOutput(TDTO dto)
    {
        return SessionData.Mapper!.MapperDTOOutput.Map<TDTO, TOutput>(dto);
    }

    internal static List<TOutput> FromDTOToOutput(List<TDTO> listDTO)
    {
        return SessionData.Mapper!.MapperDTOOutput.Map<List<TDTO>, List<TOutput>>(listDTO);
    }
    #endregion

    #region Internal
    public void SetGuid(Guid guidSessionDataRequest)
    {
        _guidSessionDataRequest = guidSessionDataRequest;
        SessionHelper.SetGuidSessionDataRequest(this, guidSessionDataRequest);
    }
    #endregion
}

public class BaseService_1<TRepository, TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>(TRepository repository) : BaseService_0<TRepository, TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TDTO, BaseValidateDTO, TInternalPropertiesDTO, BaseExternalPropertiesDTO_0, TAuxiliaryPropertyDTO>(repository), IBaseService_1<TOutput, TInputIdentifier>
        where TRepository : IBaseRepository_1<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>
        where TOutput : BaseOutput<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TDTO : BaseDTO_1<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertyDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO>, new()
{ }