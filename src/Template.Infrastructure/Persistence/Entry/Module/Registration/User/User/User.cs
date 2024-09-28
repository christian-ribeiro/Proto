using System.Text.Json.Serialization;
using Template.Arguments.Enum;
using Template.Infrastructure.Persistence.Entry.Module.Base;
using Template.Infrastructure.Persistence.Entry.Module.General;

namespace Template.Infrastructure.Persistence.Entry.Module.Registration;

public class User : BaseEntry<User>
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public EnumLanguage Language { get; private set; }
    public string? RefreshToken { get; private set; }
    public Guid? LoginKey { get; private set; }
    public string? PasswordRecoveryCode { get; private set; }

    #region Virtual Properties
    #region External
    #region User
    public virtual List<User>? ListCreationUserUser { get; private set; }
    public virtual List<User>? ListChangeUserUser { get; private set; }
    #endregion
    #region UserMenu
    public virtual List<UserMenu>? ListCreationUserUserMenu { get; private set; }
    public virtual List<UserMenu>? ListChangeUserUserMenu { get; private set; }
    #endregion
    #region EmailConfiguration
    public virtual List<EmailConfiguration>? ListCreationUserEmailConfiguration { get; private set; }
    public virtual List<EmailConfiguration>? ListChangeUserEmailConfiguration { get; private set; }
    #endregion
    #endregion
    #endregion

    public User() { }

    [JsonConstructor]
    public User(string code, string name, string password, string email, EnumLanguage language, string? refreshToken, Guid? loginKey, string? passwordRecoveryCode, List<User>? listCreationUserUser, List<User>? listChangeUserUser, List<UserMenu>? listCreationUserUserMenu, List<UserMenu>? listChangeUserUserMenu, List<EmailConfiguration>? listCreationUserEmailConfiguration, List<EmailConfiguration>? listChangeUserEmailConfiguration)
    {
        Code = code;
        Name = name;
        Password = password;
        Email = email;
        Language = language;
        RefreshToken = refreshToken;
        LoginKey = loginKey;
        PasswordRecoveryCode = passwordRecoveryCode;
        ListCreationUserUser = listCreationUserUser;
        ListChangeUserUser = listChangeUserUser;
        ListCreationUserUserMenu = listCreationUserUserMenu;
        ListChangeUserUserMenu = listChangeUserUserMenu;
        ListCreationUserEmailConfiguration = listCreationUserEmailConfiguration;
        ListChangeUserEmailConfiguration = listChangeUserEmailConfiguration;
    }
}