using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Domain.Interface.Service.Module.Base;

public interface IBaseService_0 : IBaseService_0_1<BaseOutput_0, BaseInputIdentifier_0, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0> { }

public interface IBaseService_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete>
        where TOutput : BaseOutput_0_1<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
{
    void SetGuid(Guid guidSessionDataRequest);
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
    List<BaseResponseNotification> GetListNotification();
}

public interface IBaseService_0_2<TOutput, TInputIdentifier> : IBaseService_0_1<TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0>
        where TOutput : BaseOutput_0_1<TOutput>
        where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
{ }