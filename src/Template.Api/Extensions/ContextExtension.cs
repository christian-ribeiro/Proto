using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.Persistence.Context;

namespace Template.Api.Extensions;

public static class ContextExtension
{
    public static IServiceCollection ConfigureContext(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        services.AddDbContext<AppDbContext>(cfg => cfg.UseMySQL(connectionString!).EnableSensitiveDataLogging());

        return services;
    }
}