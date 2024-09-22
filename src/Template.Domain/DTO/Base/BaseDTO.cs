using System.Reflection;
using Template.Arguments.Arguments.Base;

namespace Template.Domain.DTO.Base;

public class BaseDTO_0<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputReplace, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
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
    public Guid SessionDataRequestId { get; set; }
    public TInternalPropertiesDTO InternalPropertiesDTO { get; set; }
    public TExternalPropertiesDTO ExternalPropertiesDTO { get; set; }
    public TAuxiliaryPropertiesDTO AuxiliaryPropertiesDTO { get; set; }

    public BaseDTO_0()
    {
        InternalPropertiesDTO = new TInternalPropertiesDTO();
        ExternalPropertiesDTO = new TExternalPropertiesDTO();
        AuxiliaryPropertiesDTO = new TAuxiliaryPropertiesDTO();
    }

    public TDTO Create(TInputCreate inputCreate, TInternalPropertiesDTO? internalPropertiesDTO = default, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
    {
        foreach (PropertyInfo item in ExternalPropertiesDTO.GetType().GetProperties().ToList())
        {
            var propertyValue = inputCreate.GetType().GetProperty(item.Name)?.GetValue(inputCreate);

            if (propertyValue != null)
                item.SetValue(ExternalPropertiesDTO, propertyValue);
        }

        if (internalPropertiesDTO != null)
            InternalPropertiesDTO = internalPropertiesDTO;
        else
            InternalPropertiesDTO = new TInternalPropertiesDTO();

        InternalPropertiesDTO.SetCreateData(SessionDataRequestId);

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        return (TDTO)this;
    }

    public TDTO Create(TExternalPropertiesDTO externalPropertiesDTO, TInternalPropertiesDTO? internalPropertiesDTO = default, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
    {
        ExternalPropertiesDTO = externalPropertiesDTO;
        if (internalPropertiesDTO != null)
            InternalPropertiesDTO = internalPropertiesDTO;

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        InternalPropertiesDTO.SetCreateData(SessionDataRequestId);

        return (TDTO)this;
    }

    public TDTO Update(TInputUpdate inputUpdate, TInternalPropertiesDTO internalPropertiesDTO, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
    {
        foreach (PropertyInfo item in ExternalPropertiesDTO.GetType().GetProperties().ToList())
        {
            var propertyValue = inputUpdate.GetType().GetProperty(item.Name)?.GetValue(inputUpdate);

            if (propertyValue != null)
                item.SetValue(ExternalPropertiesDTO, propertyValue);
        }

        InternalPropertiesDTO = internalPropertiesDTO;

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        InternalPropertiesDTO.SetUpdateData(SessionDataRequestId);

        return (TDTO)this;
    }

    public TDTO Update(TExternalPropertiesDTO externalPropertiesDTO, TInternalPropertiesDTO internalPropertiesDTO, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
    {
        ExternalPropertiesDTO = externalPropertiesDTO;

        InternalPropertiesDTO = internalPropertiesDTO;

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        InternalPropertiesDTO.SetUpdateData(SessionDataRequestId);

        return (TDTO)this;
    }

    public TDTO Load(TInternalPropertiesDTO internalPropertiesDTO, TExternalPropertiesDTO externalPropertiesDTO, TAuxiliaryPropertiesDTO AuxiliaryPropertiesDTO)
    {
        return new TDTO
        {
            ExternalPropertiesDTO = externalPropertiesDTO,
            InternalPropertiesDTO = internalPropertiesDTO,
            AuxiliaryPropertiesDTO = AuxiliaryPropertiesDTO
        };
    }
}