using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Proto.Api.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Proto API",
                Description = "API de demonstração de conceito",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Christian Ribeiro",
                    Url = new Uri("https://github.com/christian-ribeiro")
                }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });

            c.TagActionsBy(api =>
            {
                var actionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                return [actionDescriptor!.ControllerName];
            });
        });

        return services;
    }

    public static WebApplication ApplySwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proto API v1");
            c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
            c.DocumentTitle = "Proto API Documentation";
            c.EnableFilter();
            c.DocExpansion(DocExpansion.None);
            c.DisplayRequestDuration();
        });
        return app;
    }
}