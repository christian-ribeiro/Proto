using System.Text.Json.Serialization;

namespace Proto.Arguments.Arguments.Module.Base;

public class BaseInputIdentityDelete<TInputIdentityDelete> where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
{
    public long Id { get; private set; }

    public BaseInputIdentityDelete() { }

    [JsonConstructor]
    public BaseInputIdentityDelete(long id)
    {
        Id = id;
    }
}

public class BaseInputIdentityDelete_0 : BaseInputIdentityDelete<BaseInputIdentityDelete_0> { }