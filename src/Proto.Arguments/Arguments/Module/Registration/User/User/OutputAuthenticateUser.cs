namespace Proto.Arguments.Arguments.Module.Registration;

public class OutputAuthenticateUser
{
    public string Token { get; private set; }
    public string? RefreshToken { get; private set; }
    public OutputUser User { get; private set; }

    public OutputAuthenticateUser(string token, string? refreshToken, OutputUser user)
    {
        Token = token;
        RefreshToken = refreshToken;
        User = user;
    }
}