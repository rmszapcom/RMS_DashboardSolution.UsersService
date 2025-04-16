using Microsoft.Extensions.DependencyInjection;
using RMS_Dashboard.Core.RepositoryContracts;
using RMS_Dashboard.Infrastructure.DbContext;
using RMS_Dashboard.Infrastructure.Repositories;

namespace RMS_Dashboard.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container
        //Infrastructure services often include data access, caching and other low-level components.

        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}