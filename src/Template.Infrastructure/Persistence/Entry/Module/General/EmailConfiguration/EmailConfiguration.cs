﻿using System.Text.Json.Serialization;
using Template.Arguments.Enum;
using Template.Infrastructure.Persistence.Entry.Module.Base;

namespace Template.Infrastructure.Persistence.Entry.Module.General;

public class EmailConfiguration : BaseEntry<EmailConfiguration>
{
    public string Server { get; private set; }
    public int Port { get; private set; }
    public string DisplayName { get; private set; }
    public string FromEmail { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool Ssl { get; private set; }
    public string? EmailCopy { get; private set; }
    public EnumEmailConfigurationType EmailConfigurationType { get; private set; }

    public EmailConfiguration() { }

    [JsonConstructor]
    public EmailConfiguration(string server, int port, string displayName, string fromEmail, string username, string password, bool ssl, string? emailCopy, EnumEmailConfigurationType emailConfigurationType)
    {
        Server = server;
        Port = port;
        DisplayName = displayName;
        FromEmail = fromEmail;
        Username = username;
        Password = password;
        Ssl = ssl;
        EmailCopy = emailCopy;
        EmailConfigurationType = emailConfigurationType;
    }
}