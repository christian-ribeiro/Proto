using Template.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureContext();
builder.Services.ConfigureCors();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureController();
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureMapper();

var app = builder.Build();

app.ApplyCors();
app.ApplyAuthentication();
app.ApplySwagger();
app.ApplyController();

app.Run();
