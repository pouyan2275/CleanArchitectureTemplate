using Application.Bases.Implements.Services;
using Application.Bases.Interfaces.IServices;
using Infrastructure.Bases;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Bases;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

        var serviceAssembly = typeof(BaseService<>).Assembly;

        var iserviceAssembly = typeof(IBaseService<>).Assembly;

        var crudServices = serviceAssembly.GetExportedTypes()
            .Where(x => x.FullName!.Contains(".Services") &&
            !x.FullName!.Contains("Base")
            )
            .ToList();
        var icrudServices = iserviceAssembly.GetExportedTypes()
            .Where(x => x.FullName!.Contains(".IServices") &&
            !x.FullName!.Contains("Base"))
            .ToList();

        for (int i = 0; i < crudServices.Count; i++)
        {
            services.AddScoped(icrudServices[i], crudServices[i]);
        }

        return services;
    }

}
