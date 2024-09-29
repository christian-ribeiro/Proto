using Microsoft.EntityFrameworkCore;
using Proto.Arguments.General.Session;
using Proto.Infrastructure.Persistence.Context;

namespace Proto.Api.Extensions;

public static class ContextExtension
{
    public static IServiceCollection ConfigureContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var connectionString = SessionData.Configuration!.GetConnectionString("DefaultConnection");
            options.UseMySQL(connectionString!);
        });

        return services;
    }
}