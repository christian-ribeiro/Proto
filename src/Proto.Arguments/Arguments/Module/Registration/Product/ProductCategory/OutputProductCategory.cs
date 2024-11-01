using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

public class OutputProductCategory : BaseOutput_0_1<OutputProductCategory>
{
    public string Code { get; set; }
    public string Description { get; set; }

    public OutputProductCategory() { }

    public OutputProductCategory(string code, string description)
    {
        Code = code;
        Description = description;
    }
}