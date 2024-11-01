using Proto.Arguments.Arguments.Module.Base;
using Proto.Domain.DTO.Module.Base;

namespace Proto.Domain.Interface.Repository.Module.Base;

public interface IBaseRepository_0 : IBaseRepository_0_1<BaseOutput_0, BaseInputIdentifier_0, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, BaseDTO_0, BaseInternalPropertiesDTO_0, BaseExternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0> { }

public interface IBaseRepository_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
       where TOutput : BaseOutput_0_1<TOutput>
       where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
       where TInputCreate : BaseInputCreate<TInputCreate>
       where TInputUpdate : BaseInputUpdate<TInputUpdate>
       where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
       where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
       where TDTO : BaseDTO_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>, new()
       where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
       where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
       where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
{
    TDTO Get(long id, bool getOnlyPrincipal = false);
    TDTO GetByIdentifier(TInputIdentifier inputIdentifier, bool getOnlyPrincipal = false);
    List<TDTO> GetAll(bool getOnlyPrincipal = false);
    List<TDTO> GetListByListIdentifier(List<TInputIdentifier> listInputIdentifier, bool getOnlyPrincipal = false);
    List<TDTO> GetListByListId(List<long> listId, bool getOnlyPrincipal = false);

    long Create(TDTO dto);
    List<long> Create(List<TDTO> listDTO);
    long Update(TDTO dto);
    List<long> Update(List<TDTO> listDTO);
    bool Delete(TDTO dto);
    bool Delete(List<TDTO> listDTO);
}

public interface IBaseRepository_0_2<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO> : IBaseRepository_0_1<TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TDTO, TInternalPropertiesDTO, BaseExternalPropertiesDTO_0, TAuxiliaryPropertyDTO>
    where TOutput : BaseOutput_0_1<TOutput>
    where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
    where TDTO : BaseDTO_0_2<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertyDTO>, new()
    where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    where TAuxiliaryPropertyDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertyDTO>, new()
{ }