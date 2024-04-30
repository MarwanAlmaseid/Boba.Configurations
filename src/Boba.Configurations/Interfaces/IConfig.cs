using System.Text.Json.Serialization;

namespace Boba.Configurations;

/// <summary>
/// Configuration interface
/// </summary>
public class IConfig
{
    /// <summary>
    /// Gets a section name to load configuration
    /// </summary>
    [JsonIgnore]
    string Name => GetType().Name;

    /// <summary>
    /// Gets an order of configuration
    /// </summary>
    /// <returns>Order</returns>
    public int GetOrder() => 1;
}
