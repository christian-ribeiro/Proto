using System.Text.Json.Serialization;
using Proto.Domain.DTO.Module.Base;

namespace Proto.Domain.DTO.Module.Registration;

public class InternalPropertiesUserDTO : BaseInternalPropertiesDTO<InternalPropertiesUserDTO>
{
    public string? RefreshToken { get; private set; }
    public Guid? LoginKey { get; private set; }
    public string? PasswordRecoveryCode { get; private set; }

    public InternalPropertiesUserDTO() { }

    [JsonConstructor]
    public InternalPropertiesUserDTO(string? refreshToken, Guid? loginKey, string? passwordRecoveryCode)
    {
        RefreshToken = refreshToken;
        LoginKey = loginKey;
        PasswordRecoveryCode = passwordRecoveryCode;
    }
}