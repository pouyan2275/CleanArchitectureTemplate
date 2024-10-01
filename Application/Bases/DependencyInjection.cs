using Application.Bases.Implements.Services;
using Application.Bases.Interfaces.IServices;
using Application.IServices;
using Application.Services;
using Domain.Bases.Interfaces.Repositories;
using Infrastructure.Bases;
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
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IDegreeService, DegreeService>();
        services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        return services;
    }

}
