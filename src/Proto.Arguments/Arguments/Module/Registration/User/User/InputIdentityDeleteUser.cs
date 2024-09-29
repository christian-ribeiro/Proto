using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityDeleteUser(long id) : BaseInputIdentityDelete<InputIdentityDeleteUser>(id) { }