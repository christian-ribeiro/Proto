using Template.Arguments.Arguments.Base;

namespace Template.Domain.Interface.Service.Base;

public interface IBaseService_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
{
    TOutput Get(long id);
    TOutput GetByIdentifier(TInputIdentifier inputIdentifier);
    List<TOutput> GetAll();
    List<TOutput> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier);
    List<TOutput> GetListByListId(List<long> listId);
    long Create(TInputCreate inputCreate);
    List<long> Create(List<TInputCreate> listInputCreate);
    long Update(TInputIdentityUpdate inputIdentityUpdate);
    List<long> Update(List<TInputIdentityUpdate> listInputIdentityUpdate);
    bool Delete(TInputIdentityDelete inputIdentityDelete);
    bool Delete(List<TInputIdentityDelete> listInputIdentityDelete);
}