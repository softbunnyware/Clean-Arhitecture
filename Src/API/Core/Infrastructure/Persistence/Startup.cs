using Application.Persistence;
using Infrastructure.Persistence.Configuration;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Initialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

internal static class Startup
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions<PersistenceSettings>()
            .BindConfiguration(nameof(PersistenceSettings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services
            .AddDbContext<ApplicationContext>((p, m) =>
            {
                var databaseSettings = config.GetSection(nameof(PersistenceSettings)).Get<PersistenceSettings>();
                m.UseDatabase(databaseSettings.DatabaseProvider, databaseSettings.ConnectionString);
            })
            .AddTransient<IDatabaseInitializer, DatabaseInitializer>()
            .AddTransient<ApplicationDbInitializer>();
    }

    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string databaseProvider, string connectionString)
    {
        switch (databaseProvider.ToLowerInvariant())
        {
            case DatabaseProvider.MSSQL:
                return builder.UseSqlServer(connectionString, e =>
                     e.MigrationsAssembly("MSSQL"));

            default:
                throw new InvalidOperationException($"DB Provider {databaseProvider} is not supported.");
        }
    }
}
