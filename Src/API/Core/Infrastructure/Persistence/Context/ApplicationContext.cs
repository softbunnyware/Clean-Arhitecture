using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext() 
    { 
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
}
