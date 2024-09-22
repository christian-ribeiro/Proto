using Template.Domain.Interface.Repository;
using Template.Domain.Interface.Service;
using Template.Domain.Service;
using Template.Infrastructure.Persistence.Repository;

namespace Template.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<IUserService, UserService>();
        #endregion

        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion

        return services;
    }
}