using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityUpdateProduct(long id, InputUpdateProduct? inputUpdate) : BaseInputIdentityUpdate<InputUpdateProduct>(id, inputUpdate) { }