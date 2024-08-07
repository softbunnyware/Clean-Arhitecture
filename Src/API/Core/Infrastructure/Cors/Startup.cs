using Application.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Cors;

internal static class Startup
{
    private const string CorsOpenPolicy = nameof(CorsOpenPolicy);

    internal static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
    {
        var corsSettings = config.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
        var origins = new List<string>();

        if (!string.IsNullOrEmpty(corsSettings?.Clients))
        {
            origins.AddRange(corsSettings.Clients.Split(';', StringSplitOptions.RemoveEmptyEntries));
        }

        return services.AddCors(opt =>
            opt.AddPolicy(CorsOpenPolicy, policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins(origins.ToArray())));
    }

    internal static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
    {
        return app.UseCors(CorsOpenPolicy);
    }
}
