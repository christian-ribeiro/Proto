using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

[method: JsonConstructor]
public class InputIdentityUpdateUserMenu(long id, InputUpdateUserMenu? inputUpdate) : BaseInputIdentityUpdate<InputUpdateUserMenu>(id, inputUpdate) { }