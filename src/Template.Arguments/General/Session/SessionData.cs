using System.Collections.Concurrent;

namespace Template.Arguments.General.Session;

public static class SessionData
{
    public static ConcurrentDictionary<Guid, SessionDataRequest> ListSessionDataRequest = new();

    public static Guid Initialize()
    {
        return Add(new SessionDataRequest());
    }

    public static Guid Add(SessionDataRequest sessionDataRequest)
    {
        ListSessionDataRequest.TryAdd(sessionDataRequest.SessionDataRequestId, sessionDataRequest);
        return sessionDataRequest.SessionDataRequestId;
    }

    public static void SetLoggedUser(Guid sessionDataRequestId, LoggedUser loggedUser)
    {
        ListSessionDataRequest[sessionDataRequestId].LoggedUser = loggedUser;
    }

    public static LoggedUser? GetLoggedUser(Guid sessionDataRequestId)
    {
        return ListSessionDataRequest[sessionDataRequestId].LoggedUser;
    }

    public static SessionDataRequest Get(Guid sessionDataRequestId)
    {
        return ListSessionDataRequest[sessionDataRequestId];
    }

    public static void Remove(Guid sessionDataId)
    {
        ListSessionDataRequest.TryRemove(sessionDataId, out SessionDataRequest? sessionDataRequest);
    }
}