using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

public class InputRefreshTokenUser
{
    public string Token { get; private set; }
    public string RefreshToken { get; private set; }

    [JsonConstructor]
    public InputRefreshTokenUser(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}