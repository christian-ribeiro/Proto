using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Base;

public class BaseInputIdentityView<TInputIdentityView> where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
{
    public long Id { get; private set; }

    public BaseInputIdentityView() { }

    [JsonConstructor]
    public BaseInputIdentityView(long id)
    {
        Id = id;
    }
}

public class BaseInputIdentityView_0 : BaseInputIdentityView<BaseInputIdentityView_0> { }