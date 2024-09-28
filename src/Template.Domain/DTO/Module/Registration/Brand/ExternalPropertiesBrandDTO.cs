using System.Text.Json.Serialization;
using Template.Domain.DTO.Module.Base;

namespace Template.Domain.DTO.Module.Registration;

public class ExternalPropertiesBrandDTO : BaseExternalPropertiesDTO<ExternalPropertiesBrandDTO>
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    public ExternalPropertiesBrandDTO() { }

    [JsonConstructor]
    public ExternalPropertiesBrandDTO(string code, string description)
    {
        Code = code;
        Description = description;
    }
}