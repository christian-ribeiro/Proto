namespace Template.Arguments.Arguments.Module.Base;

public class BaseResponseApi<TResult>
{
    public TResult? Result { get; set; }
    public string? ErrorMessage { get; set; }
}