namespace Template.Arguments.General.Session;

public class SessionDataRequest
{
    public Guid SessionDataRequestId { get; }
    public LoggedUser? LoggedUser { get; set; }

    public SessionDataRequest()
    {
        SessionDataRequestId = Guid.NewGuid();
    }
}