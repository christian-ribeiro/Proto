using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Proto.Api.Extensions
{
    public static class CompressionExtension
    {
        public static IServiceCollection ConfigureCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            return services;
        }
    }
}
