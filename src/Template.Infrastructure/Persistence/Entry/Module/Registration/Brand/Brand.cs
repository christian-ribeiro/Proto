using System.Text.Json.Serialization;
using Template.Infrastructure.Persistence.Entry.Module.Base;

namespace Template.Infrastructure.Persistence.Entry.Module.Registration;

public class Brand : BaseEntry<Brand>
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    public Brand() { }

    [JsonConstructor]
    public Brand(string code, string description)
    {
        Code = code;
        Description = description;
    }
}