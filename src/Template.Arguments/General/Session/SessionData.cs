using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using Template.Api.Mapper;

namespace Template.Arguments.General.Session;

public static class SessionData
{
    public static ConcurrentDictionary<Guid, SessionDataRequest> ListSessionDataRequest = new();
    public static Mapper? Mapper { get; private set; }
    public static IConfiguration? Configuration { get; private set; }

    public static Guid Initialize()
    {
        return Add(new SessionDataRequest());
    }

    public static Guid Add(SessionDataRequest guidSessionDataRequest)
    {
        ListSessionDataRequest.TryAdd(guidSessionDataRequest.GuidSessionDataRequest, guidSessionDataRequest);
        return guidSessionDataRequest.GuidSessionDataRequest;
    }

    public static void SetLoggedUser(Guid guidSessionDataRequest, LoggedUser loggedUser)
    {
        ListSessionDataRequest[guidSessionDataRequest].LoggedUser = loggedUser;
    }

    public static LoggedUser? GetLoggedUser(Guid guidSessionDataRequest)
    {
        return ListSessionDataRequest[guidSessionDataRequest].LoggedUser;
    }

    public static void Remove(Guid sessionDataId)
    {
        ListSessionDataRequest.TryRemove(sessionDataId, out SessionDataRequest? guidSessionDataRequest);
    }

    public static void SetMapper(Mapper mapper)
    {
        Mapper = mapper;
    }

    public static void SetConfiguration(IConfiguration configuration)
    {
        Configuration = configuration;
    }
}