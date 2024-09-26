using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

[method: JsonConstructor]
public class InputIdentityUpdateUser(long id, InputUpdateUser? inputUpdate) : BaseInputIdentityUpdate<InputUpdateUser>(id, inputUpdate) { }