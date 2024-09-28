using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityUpdateBrand(long id, InputUpdateBrand? inputUpdate) : BaseInputIdentityUpdate<InputUpdateBrand>(id, inputUpdate) { }