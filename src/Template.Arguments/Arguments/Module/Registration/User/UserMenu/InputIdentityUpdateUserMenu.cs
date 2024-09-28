using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityUpdateUserMenu(long id, InputUpdateUserMenu? inputUpdate) : BaseInputIdentityUpdate<InputUpdateUserMenu>(id, inputUpdate) { }