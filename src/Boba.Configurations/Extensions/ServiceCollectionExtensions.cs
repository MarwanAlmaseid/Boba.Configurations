using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boba.Configurations;

/// <summary>
/// Provides extension methods for configuring services in the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBobaConfigurations(this IServiceCollection services, IConfigurationManager configuration)
    {
        var appDomain = new AppDomainTypeFinder();
        var configs = appDomain.FindClassesOfType(typeof(IConfig), true).ToList();

        foreach (var configType in configs)
        {
            var configName = configType.Name;

            var config = configuration.GetSection(configName).Get(configType);

            if (config is not null)
            {
                services.AddSingleton(configType, config);
            }
        }

        return services;
    }
}