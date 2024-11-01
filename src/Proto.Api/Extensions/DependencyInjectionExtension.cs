using AutoMapper;
using Lamar.Microsoft.DependencyInjection;
using Proto.Arguments.AutoMapper;
using Proto.Domain.Interface;
using Proto.Infrastructure.Persistence;

namespace Proto.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static ConfigureHostBuilder ConfigureDependencyInjection(this ConfigureHostBuilder host)
    {
        var configure = new MapperConfiguration(config => { config.AddProfile(new MapperGeneric<object, object>()); });
        IMapper mapperGeneric = configure.CreateMapper();

        host.UseLamar((context, registry) =>
        {
            registry.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            registry.AddTransient<IUnitOfWork, UnityOfWork>();

            registry.Scan(scanner =>
            {
                scanner.Assembly("Proto.Domain");
                scanner.Assembly("Proto.Infrastructure");
                scanner.Assembly("Proto.Utilities");
                scanner.WithDefaultConventions();
            });
        });

        return host;
    }
}