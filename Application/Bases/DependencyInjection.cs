using Application.Bases.Implements.Services;
using Application.Bases.Interfaces.IServices;
using Application.IServices;
using Application.Services;
using Domain.Bases.Interfaces.Repositories;
using Infrastructure.Bases;
using Infrastructure.Bases.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Bases;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

        var serviceAssembly = typeof(CrudService<>).Assembly;

        var iserviceAssembly = typeof(ICrudService<>).Assembly;

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
