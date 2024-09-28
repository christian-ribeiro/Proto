using AutoMapper;
using Template.Arguments.AutoMapper;
using Template.Domain.Interface;
using Template.Domain.Interface.Repository.Module.General;
using Template.Domain.Interface.Repository.Module.Registration;
using Template.Domain.Interface.Service.Module.General;
using Template.Domain.Interface.Service.Module.Registration;
using Template.Domain.Service.Module.General;
using Template.Domain.Service.Module.Registration;
using Template.Infrastructure.Persistence;
using Template.Infrastructure.Persistence.Repository.Module.General;
using Template.Infrastructure.Persistence.Repository.Module.Registration;
using Template.Utilities.Interface.Service;
using Template.Utilities.Service;

namespace Template.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        var configure = new MapperConfiguration(config => { config.AddProfile(new MapperGeneric<object, object>()); });
        IMapper mapperGeneric = configure.CreateMapper();
        services.AddSingleton(mapperGeneric);
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUnitOfWork, UnityOfWork>();
        services.AddScoped<IEmailService, EmailService>();

        #region Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IUserMenuService, UserMenuService>();
        services.AddScoped<IEmailConfigurationService, EmailConfigurationService>();
        services.AddScoped<IBrandService, BrandService>();
        #endregion

        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IUserMenuRepository, UserMenuRepository>();
        services.AddScoped<IEmailConfigurationRepository, EmailConfigurationRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        #endregion

        return services;
    }
}