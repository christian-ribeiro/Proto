﻿using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class InternalPropertiesUserDTO : BaseInternalPropertiesDTO<InternalPropertiesUserDTO>
{
    public string? RefreshToken { get; private set; }
    public Guid? LoginKey { get; private set; }

    public InternalPropertiesUserDTO() { }

    [JsonConstructor]
    public InternalPropertiesUserDTO(string? refreshToken, Guid? loginKey)
    {
        RefreshToken = refreshToken;
        LoginKey = loginKey;
    }
}