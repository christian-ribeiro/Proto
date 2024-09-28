using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityDeleteUserMenu(long id) : BaseInputIdentityDelete<InputIdentityDeleteUserMenu>(id) { }