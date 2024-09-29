using System.Text.Json.Serialization;
using Proto.Arguments.Enum;
using Proto.Domain.DTO.Module.Base;

namespace Proto.Domain.DTO.Module.Registration;

public class ExternalPropertiesUserDTO : BaseExternalPropertiesDTO<ExternalPropertiesUserDTO>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public EnumLanguage Language { get; private set; }

    public ExternalPropertiesUserDTO() { }

    [JsonConstructor]
    public ExternalPropertiesUserDTO(string code, string name, string password, string email, EnumLanguage language)
    {
        Code = code;
        Name = name;
        Password = password;
        Email = email;
        Language = language;
    }
}