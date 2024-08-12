using Application;
using Application.Features.Actors;
using Infrastructure.Cache;
using Infrastructure.Cors;
using Infrastructure.Features;
using Infrastructure.OpenAPI;
using Infrastructure.OpenTelemetry;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Initialization;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var assemblies = new[]
        {
            Assembly.GetExecutingAssembly(),
            typeof(ApplicationMarker).Assembly
        };

        return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies))
            .AddOpenAPI(config)
            .AddPersistence(config)
            .AddEndpointsApiExplorer()
            .AddOpenTelemetry(config)
            .AddCaching(config)
            .AddCorsPolicy(config)
            .AddServices();
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseHttpsRedirection()
            .UseOpenAPI();
    }

    public static void InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var scope = services.CreateScope();
        scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>()
            .InitializeDatabasesAsync(cancellationToken);
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers();
        return builder;
    }
}
