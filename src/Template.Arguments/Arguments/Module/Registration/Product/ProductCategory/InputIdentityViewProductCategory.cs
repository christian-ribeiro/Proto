﻿using System.Text.Json.Serialization;
using Template.Arguments.Arguments.Module.Base;

namespace Template.Arguments.Arguments.Module.Registration;

[method: JsonConstructor]
public class InputIdentityViewProductCategory(long id) : BaseInputIdentityView<InputIdentityViewProductCategory>(id) { }