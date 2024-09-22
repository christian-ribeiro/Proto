using Template.Arguments.Enum;
using Template.Infrastructure.Persistence.Entry.Base;

namespace Template.Infrastructure.Persistence.Entry;

public class User : BaseEntry<User>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public EnumLanguage Language { get; private set; }
    public string RefreshToken { get; private set; }
    public Guid LoginKey { get; private set; }

    #region Virtual Properties
    #region External
    public virtual List<User> ListCreationUserUser { get; private set; }
    public virtual List<User> ListChangeUserUser { get; private set; }
    #endregion
    #endregion

    public User() { }

    public User(string code, string name, string password, string email, EnumLanguage language, string refreshToken, Guid loginKey, List<User> listCreationUserUser, List<User> listChangeUserUser)
    {
        Code = code;
        Name = name;
        Password = password;
        Email = email;
        Language = language;
        RefreshToken = refreshToken;
        LoginKey = loginKey;
        ListCreationUserUser = listCreationUserUser;
        ListChangeUserUser = listChangeUserUser;
    }
}