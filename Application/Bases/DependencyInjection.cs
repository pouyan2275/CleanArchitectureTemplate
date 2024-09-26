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

    public static string AttributeDescription(this object value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString() ?? "");

        DescriptionAttribute[]? attributes = fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Length != 0)
        {
            return attributes.First().Description;
        }

        return value.ToString() ?? "";
    }

}
