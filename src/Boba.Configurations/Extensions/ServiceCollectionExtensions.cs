using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boba.Configurations;

/// <summary>
/// Provides extension methods for configuring services in the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Boba configurations to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the configurations to.</param>
    /// <param name="configuration">The <see cref="IConfigurationManager"/> containing the configuration data.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
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