using System.Text.Json.Serialization;
using Proto.Arguments.Enum;
using Proto.Infrastructure.Persistence.Entity.Module.Base;
using Proto.Infrastructure.Persistence.Entity.Module.General;

namespace Proto.Infrastructure.Persistence.Entity.Module.Registration;

public class User : BaseEntity<User>
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
    #region Brand
    public virtual List<Brand>? ListCreationUserBrand { get; private set; }
    public virtual List<Brand>? ListChangeUserBrand { get; private set; }
    #endregion
    #region Product
    public virtual List<Product>? ListCreationUserProduct { get; private set; }
    public virtual List<Product>? ListChangeUserProduct { get; private set; }
    #endregion
    #region ProductCategory
    public virtual List<ProductCategory>? ListCreationUserProductCategory { get; private set; }
    public virtual List<ProductCategory>? ListChangeUserProductCategory { get; private set; }
    #endregion
    #endregion
    #endregion

    public User() { }

    public User(string code, string name, string password, string email, EnumLanguage language, string? refreshToken, Guid? loginKey, string? passwordRecoveryCode)
    {
        Code = code;
        Name = name;
        Password = password;
        Email = email;
        Language = language;
        RefreshToken = refreshToken;
        LoginKey = loginKey;
        PasswordRecoveryCode = passwordRecoveryCode;
    }

    [JsonConstructor]
    public User(string code, string name, string password, string email, EnumLanguage language, string? refreshToken, Guid? loginKey, string? passwordRecoveryCode, List<User>? listCreationUserUser, List<User>? listChangeUserUser, List<UserMenu>? listCreationUserUserMenu, List<UserMenu>? listChangeUserUserMenu, List<EmailConfiguration>? listCreationUserEmailConfiguration, List<EmailConfiguration>? listChangeUserEmailConfiguration, List<Brand>? listCreationUserBrand, List<Brand>? listChangeUserBrand, List<Product>? listCreationUserProduct, List<Product>? listChangeUserProduct, List<ProductCategory>? listCreationUserProductCategory, List<ProductCategory>? listChangeUserProductCategory)
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
        ListCreationUserBrand = listCreationUserBrand;
        ListChangeUserBrand = listChangeUserBrand;
        ListCreationUserProduct = listCreationUserProduct;
        ListChangeUserProduct = listChangeUserProduct;
        ListCreationUserProductCategory = listCreationUserProductCategory;
        ListChangeUserProductCategory = listChangeUserProductCategory;
    }
}