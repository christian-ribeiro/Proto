﻿using System.Text.Json.Serialization;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputSendEmailRedefinePasswordUser(string email)
{
    public string Email { get; private set; } = email;
}