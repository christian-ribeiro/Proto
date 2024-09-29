using AutoMapper;
using Proto.Arguments.AutoMapper;
using Proto.Domain.Interface;
using Proto.Domain.Interface.Repository.Module.General;
using Proto.Domain.Interface.Repository.Module.Registration;
using Proto.Domain.Interface.Service.Module.General;
using Proto.Domain.Interface.Service.Module.Registration;
using Proto.Domain.Service.Module.General;
using Proto.Domain.Service.Module.Registration;
using Proto.Infrastructure.Persistence;
using Proto.Infrastructure.Persistence.Repository.Module.General;
using Proto.Infrastructure.Persistence.Repository.Module.Registration;
using Proto.Utilities.Interface.Service;
using Proto.Utilities.Service;

namespace Proto.Api.Extensions;

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
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        #endregion

        #region Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IUserMenuRepository, UserMenuRepository>();
        services.AddScoped<IEmailConfigurationRepository, EmailConfigurationRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        #endregion

        return services;
    }
}