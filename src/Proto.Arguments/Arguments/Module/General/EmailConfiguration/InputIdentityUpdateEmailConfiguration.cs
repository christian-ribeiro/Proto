using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.General;

[method: JsonConstructor]
public class InputIdentityUpdateEmailConfiguration(long id, InputUpdateEmailConfiguration? inputUpdate) : BaseInputIdentityUpdate<InputUpdateEmailConfiguration>(id, inputUpdate) { }