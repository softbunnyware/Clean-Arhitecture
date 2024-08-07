using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.OpenAPI;

internal static class Startup
{
    internal static IServiceCollection AddOpenAPI(this IServiceCollection services, IConfiguration config)
    {
        return services.AddSwaggerGen();
    }

    internal static IApplicationBuilder UseOpenAPI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
