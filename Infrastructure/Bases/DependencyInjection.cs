using Infrastructure.Bases.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Bases.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Bases.Interfaces.Repositories;

namespace Infrastructure.Bases;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>((conf, option) =>
        {
            var configuration = conf.GetRequiredService<IConfiguration>();
            option.UseSqlServer(configuration.GetConnectionString("BaseConnection"),
                dboption => dboption.EnableRetryOnFailure());
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        var repositoryAssembly = typeof(Repository<>).Assembly;

        var irepositoryAssembly = typeof(IRepository<>).Assembly;

        var repositories = repositoryAssembly.GetExportedTypes()
            .Where(x => x.FullName!.Contains("Repositories") &&
            !x.FullName!.Contains("Base")
            )
            .ToList();
        var irepositories = irepositoryAssembly.GetExportedTypes()
            .Where(x => x.FullName!.Contains("Repositories") &&
            !x.FullName!.Contains("Base"))
            .ToList();

        for (int i = 0; i < repositories.Count; i++)
        {
            services.AddScoped(irepositories[i], repositories[i]);
        }

        return services;
    }
}
