﻿using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Initialization;

public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task InitializeDatabasesAsync(CancellationToken cancellationToken)
    {
        await InitializeDataDb(cancellationToken);
    }

    public async Task InitializeDataDb(CancellationToken cancellationToken)
    {
        var scope = _serviceProvider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>().InitializeAsync(cancellationToken);
    }
}
