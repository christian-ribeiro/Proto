using Proto.Arguments.Arguments.Module.Base;
using Proto.Arguments.Enum;
using Proto.Arguments.General.Session;
using Proto.Domain.DTO.Module.Base;
using Proto.Domain.Interface.Repository.Module.Base;
using Proto.Domain.Interface.Service.Module.Base;
using System.Text.RegularExpressions;

namespace Proto.Domain.Service.Module.Base;

public class BaseService_0 : BaseService_0_1<IBaseRepository_0, BaseOutput_0, BaseInputIdentifier_0, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, BaseDTO_0, BaseValidateDTO, BaseInternalPropertiesDTO_0, BaseExternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0> { }
public class BaseService_0_1<TRepository, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TValidateDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO> : IBaseService_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete>
        where TRepository : IBaseRepository_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TOutput : BaseOutput_0_1<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TDTO : BaseDTO_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>, new()
        where TValidateDTO : BaseValidateDTO
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
{
    public Guid _guidSessionDataRequest;
    protected readonly TRepository _repository;

    public BaseService_0_1() { }

    public BaseService_0_1(TRepository repository)
    {
        _repository = repository;
    }

    public List<BaseResponseNotification> _listNotification { get; private set; } = [];

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

    public bool DecimalLowerThan(decimal minValue, decimal? value)
    {
        return value < minValue;
    }

    public bool InvalidRelatedProperty<TRelatedDTO>(long? value, TRelatedDTO relatedProperty)
    {
        return value != null && relatedProperty == null;
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

    protected bool AddNotification(int index, string message)
    {
        _listNotification.Add(new BaseResponseNotification { Index = index, Message = message });
        return true;
    }

    protected bool AddNotification(TInputIdentifier identifier, string message)
    {
        _listNotification.Add(new BaseResponseNotification { Identifier = identifier, Message = message });
        return true;
    }

    protected bool AddNotification(long id, TInputIdentifier identifier, string message)
    {
        _listNotification.Add(new BaseResponseNotification { Id = id, Identifier = identifier, Message = message });
        return true;
    }

    public List<BaseResponseNotification> GetListNotification() => _listNotification;
    #endregion
}

public class BaseService_0_2<TRepository, TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>(TRepository repository) : BaseService_0_1<TRepository, TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TDTO, BaseValidateDTO, TInternalPropertiesDTO, BaseExternalPropertiesDTO_0, TAuxiliaryPropertyDTO>(repository), IBaseService_0_2<TOutput, TInputIdentifier>
        where TRepository : IBaseRepository_0_2<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>
        where TOutput : BaseOutput_0_1<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TDTO : BaseDTO_0_2<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertyDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO>, new()
{ }