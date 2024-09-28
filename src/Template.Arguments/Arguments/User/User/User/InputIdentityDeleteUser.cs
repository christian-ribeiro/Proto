using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Base;

namespace Template.Arguments.Arguments;

[method: JsonConstructor]
public class InputIdentityDeleteUser(long id) : BaseInputIdentityDelete<InputIdentityDeleteUser>(id) { }