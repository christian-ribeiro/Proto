using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityViewUser(long id)
{
    public long Id { get; private set; } = id;
}