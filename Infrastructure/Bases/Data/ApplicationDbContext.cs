using Domain.Bases.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Bases.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entities = Assembly.GetAssembly(typeof(IBaseEntity))?.GetTypes()
        .Where(x => x.IsClass).ToList();
        entities?.ForEach(entity =>
        {
            modelBuilder.Entity(entity);
        });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}