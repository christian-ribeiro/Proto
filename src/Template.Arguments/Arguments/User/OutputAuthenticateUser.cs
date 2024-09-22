namespace Template.Arguments.Arguments;

public class OutputAuthenticateUser
{
    public string Token { get; private set; }
    public OutputUser User { get; private set; }

    public OutputAuthenticateUser(string token, OutputUser user)
    {
        Token = token;
        User = user;
    }
}