using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.General;

[method: JsonConstructor]
public class InputIdentityUpdateEmailConfiguration(long id, InputUpdateEmailConfiguration? inputUpdate) : BaseInputIdentityUpdate<InputUpdateEmailConfiguration>(id, inputUpdate) { }