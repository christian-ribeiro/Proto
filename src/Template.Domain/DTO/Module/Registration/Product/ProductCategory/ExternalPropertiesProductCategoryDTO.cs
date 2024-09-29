﻿using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class ExternalPropertiesProductCategoryDTO : BaseExternalPropertiesDTO<ExternalPropertiesProductCategoryDTO>
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    public ExternalPropertiesProductCategoryDTO() { }

    [JsonConstructor]
    public ExternalPropertiesProductCategoryDTO(string code, string description)
    {
        Code = code;
        Description = description;
    }
}