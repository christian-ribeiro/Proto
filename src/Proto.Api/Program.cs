using Proto.Api.Extensions;
using Proto.Arguments.General.Session;

var builder = WebApplication.CreateBuilder(args);

SessionData.SetConfiguration(builder.Configuration);

builder.Services.ConfigureContext();
builder.Services.ConfigureCors();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureController();
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureMapper();

var app = builder.Build();

app.UseStaticFiles();
app.ApplyCors();
app.ApplyAuthentication();
app.ApplySwagger();
app.ApplyController();

app.Run();