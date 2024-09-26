using Domain.Bases.Interfaces.Repositories;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Infrastructure.Bases.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Bases.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Bases;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>((conf, option) =>
        {
            var configuration = conf.GetRequiredService<IConfiguration>();
            option.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IDegreeRepository, DegreeRepository>();

        return services;
    }
}
