using Template.Arguments.Arguments.Base;
using Template.Domain.DTO.Base;
using Template.Domain.Interface.Repository.Base;
using Template.Domain.Interface.Service.Base;

namespace Template.Domain.Service.Base;

public class BaseService_0<TRepository, TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>(TRepository repository) : IBaseService_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete>
        where TRepository : IBaseRepository_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TOutput : BaseOutput<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TDTO : BaseDTO_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
{
    protected readonly TRepository _repository = repository;

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

    public long Create(TInputCreate inputCreate)
    {
        return Create([inputCreate]).FirstOrDefault();
    }

    public virtual List<long> Create(List<TInputCreate> listInputCreate)
    {
        throw new NotImplementedException();
    }
    public long Update(TInputIdentityUpdate inputIdentityUpdate)
    {
        return Update([inputIdentityUpdate]).FirstOrDefault();
    }

    public virtual List<long> Update(List<TInputIdentityUpdate> listInputIdentityUpdate)
    {
        throw new NotImplementedException();
    }

    public virtual List<long> Replace(List<TInputReplace> listInputReplace)
    {
        throw new NotImplementedException();
    }

    public bool Delete(TInputIdentityDelete inputIdentityDelete)
    {
        return Delete([inputIdentityDelete]);
    }

    public virtual bool Delete(List<TInputIdentityDelete> listInputIdentityDelete)
    {
        throw new NotImplementedException();
    }

    internal TOutput FromDTOToOutput(TDTO dto)
    {
        return (TOutput)(dynamic)dto;
    }

    internal List<TOutput> FromDTOToOutput(List<TDTO> listDTO)
    {
        return (from i in listDTO select (TOutput)(dynamic)i).ToList();
    }
}