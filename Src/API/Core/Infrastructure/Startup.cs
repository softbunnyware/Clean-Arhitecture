using Infrastructure.Cache;
using Infrastructure.Cors;
using Infrastructure.OpenAPI;
using Infrastructure.OpenTelemetry;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddOpenAPI(config)
            .AddPersistence(config)
            .AddEndpointsApiExplorer()
            .AddOpenTelemetry(config)
            .AddCaching(config)
            .AddCorsPolicy(config);
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseHttpsRedirection()
            .UseAuthorization()
            .UseOpenAPI();
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers().RequireAuthorization();
        return builder;
    }
}
