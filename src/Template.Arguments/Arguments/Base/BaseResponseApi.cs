namespace Template.Arguments.Arguments.Base;

public class BaseResponseApi<TResult>
{
    public TResult? Result { get; set; }
    public string? ErrorMessage { get; set; }
}