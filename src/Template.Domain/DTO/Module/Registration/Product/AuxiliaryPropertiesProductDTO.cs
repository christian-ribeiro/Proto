﻿using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class AuxiliaryPropertiesProductDTO : BaseAuxiliaryPropertiesDTO<AuxiliaryPropertiesProductDTO>
{
    #region Virtual Properties
    #region Internal
    public BrandDTO? Brand { get; private set; }
    #endregion
    #endregion
    public AuxiliaryPropertiesProductDTO() { }

    [JsonConstructor]
    public AuxiliaryPropertiesProductDTO(BrandDTO? brand)
    {
        Brand = brand;
    }
}