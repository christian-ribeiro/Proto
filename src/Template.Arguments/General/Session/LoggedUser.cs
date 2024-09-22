namespace Template.Arguments.General.Session;

public class LoggedUser(long id, string name, string email)
{
    public long Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
}