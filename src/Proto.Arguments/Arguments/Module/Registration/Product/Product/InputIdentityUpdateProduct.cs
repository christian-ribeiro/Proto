using System.Text.Json.Serialization;
using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityUpdateProduct(long id, InputUpdateProduct? inputUpdate) : BaseInputIdentityUpdate<InputUpdateProduct>(id, inputUpdate) { }