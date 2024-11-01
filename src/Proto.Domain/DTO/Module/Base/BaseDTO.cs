using System.Reflection;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Domain.DTO.Module.Base;

public class BaseDTO_0 : BaseDTO_0_1<BaseOutput_0, BaseInputIdentifier_0, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, BaseDTO_0, BaseInternalPropertiesDTO_0, BaseExternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0> { }

public class BaseDTO_0_1<TOutput, TInputIdentifier, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TDTO, TInternalPropertiesDTO, TExternalPropertiesDTO, TAuxiliaryPropertiesDTO>
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
    public TInternalPropertiesDTO InternalPropertiesDTO { get; set; }
    public TExternalPropertiesDTO ExternalPropertiesDTO { get; set; }
    public TAuxiliaryPropertiesDTO AuxiliaryPropertiesDTO { get; set; }

    public BaseDTO_0_1()
    {
        InternalPropertiesDTO = new TInternalPropertiesDTO();
        ExternalPropertiesDTO = new TExternalPropertiesDTO();
        AuxiliaryPropertiesDTO = new TAuxiliaryPropertiesDTO();
    }

    public TDTO Create(Guid guidSessionDataRequest, TInputCreate inputCreate, TInternalPropertiesDTO? internalPropertiesDTO = default, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
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

        InternalPropertiesDTO.SetCreateData(guidSessionDataRequest);

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        return (TDTO)this;
    }

    public TDTO Create(Guid guidSessionDataRequest, TExternalPropertiesDTO externalPropertiesDTO, TInternalPropertiesDTO? internalPropertiesDTO = default, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
    {
        ExternalPropertiesDTO = externalPropertiesDTO;
        if (internalPropertiesDTO != null)
            InternalPropertiesDTO = internalPropertiesDTO;

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        InternalPropertiesDTO.SetCreateData(guidSessionDataRequest);

        return (TDTO)this;
    }

    public TDTO Update(Guid guidSessionDataRequest, TInputUpdate inputUpdate, TInternalPropertiesDTO internalPropertiesDTO, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
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

        InternalPropertiesDTO.SetUpdateData(guidSessionDataRequest);

        return (TDTO)this;
    }

    public TDTO Update(Guid guidSessionDataRequest, TExternalPropertiesDTO externalPropertiesDTO, TInternalPropertiesDTO internalPropertiesDTO, TAuxiliaryPropertiesDTO? auxiliaryPropertiesDTO = default)
    {
        ExternalPropertiesDTO = externalPropertiesDTO;

        InternalPropertiesDTO = internalPropertiesDTO;

        if (auxiliaryPropertiesDTO != null)
            AuxiliaryPropertiesDTO = auxiliaryPropertiesDTO;

        InternalPropertiesDTO.SetUpdateData(guidSessionDataRequest);

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

public class BaseDTO_0_2<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryProperty> : BaseDTO_0_1<TOutput, TInputIdentifier, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TDTO, TInternalPropertiesDTO, BaseExternalPropertiesDTO_0, TAuxiliaryProperty>
    where TOutput : BaseOutput_0_1<TOutput>
    where TInputIdentifier : BaseInputIdentifier<TInputIdentifier>, new()
    where TDTO : BaseDTO_0_2<TOutput, TInputIdentifier, TDTO, TInternalPropertiesDTO, TAuxiliaryProperty>, new()
    where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    where TAuxiliaryProperty : BaseAuxiliaryPropertiesDTO<TAuxiliaryProperty>, new()
{ }