﻿using Proto.Arguments.Arguments.Module.Base;

namespace Proto.Arguments.Arguments.Module.Registration;

public class OutputBrand : BaseOutput<OutputBrand>
{
    public string Code { get; set; }
    public string Description { get; set; }

    public OutputBrand() { }

    public OutputBrand(string code, string description)
    {
        Code = code;
        Description = description;
    }
}