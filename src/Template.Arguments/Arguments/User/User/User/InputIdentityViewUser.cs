using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments;

[method: JsonConstructor]
public class InputIdentityViewUser(long id)
{
    public long Id { get; private set; } = id;
}