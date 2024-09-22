namespace Template.Api.Extensions;

public static class CorsExtension
{
    private static string CorsPolicy = "Template";
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy, builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        return services;
    }

    public static WebApplication ApplyCors(this WebApplication app)
    {
        app.UseCors(CorsPolicy);
        return app;
    }
}