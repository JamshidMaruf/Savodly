using Microsoft.EntityFrameworkCore;
using Savodly.Domain.Entities;

namespace Savodly.DataAccess.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        var entityAssembly = typeof(Auditable).Assembly;
        var entityTypes = entityAssembly
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(Auditable).IsAssignableFrom(t));

        foreach (var type in entityTypes)
            modelBuilder.Entity(type);
    }
}
