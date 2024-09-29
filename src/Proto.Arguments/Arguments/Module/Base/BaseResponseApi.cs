namespace Proto.Arguments.Arguments.Module.Base;

public class BaseResponseApi<TResult>
{
    public TResult? Result { get; set; }
    public string? ErrorMessage { get; set; }
    public List<BaseResponseNotification>? ListNotification { get; set; }
}