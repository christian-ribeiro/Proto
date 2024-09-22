using Template.Arguments.Arguments.Base;
using Template.Domain.DTO.Base;

namespace Template.Domain.Interface.Repository.Base;

public interface IBaseRepository_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
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