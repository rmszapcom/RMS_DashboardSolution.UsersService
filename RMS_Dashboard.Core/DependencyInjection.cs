using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RMS_Dashboard.Core.ServiceContracts;
using RMS_Dashboard.Core.Services;
using RMS_Dashboard.Core.Validators;

namespace RMS_Dashboard.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container
        //Infrastructure services often include data access, caching and other low-level components.

        services.AddTransient<IUsersService, UsersService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}