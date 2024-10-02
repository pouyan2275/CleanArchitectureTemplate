using Domain.Bases.Entities;
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
        var entities = Assembly.GetAssembly(typeof(BaseEntity))?.GetTypes();

        foreach (var entity in entities!)
        {
            if (entity.IsSubclassOf(typeof(BaseEntity)) && !entity.IsAbstract)
                modelBuilder.Entity(entity)
                .HasIndex("IsDeleted")
                .HasFilter("IsDeleted = 0");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}