using Application.Cache;
using Application.Cache.Abstractions;
using Infrastructure.Cache.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Cache;

internal static class Startup
{
    internal static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICacheService, CacheService>();
        var cacheOptions = configuration.GetSection(nameof(CacheSettings)).Get<CacheSettings>();

        if (string.IsNullOrEmpty(cacheOptions?.Redis))
        {
            services.AddDistributedMemoryCache();
            return services;
        }

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = cacheOptions?.Redis;
            options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
            {
                AbortOnConnectFail = true,
                EndPoints = { cacheOptions?.Redis! }
            };
        });

        return services;
    }
}
