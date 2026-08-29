using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Polymarket.HttpClients.Registrars;
using Soenneker.Polymarket.OpenApiClientUtil.Abstract;

namespace Soenneker.Polymarket.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class PolymarketOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="PolymarketOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPolymarketOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPolymarketOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPolymarketOpenApiClientUtil, PolymarketOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PolymarketOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPolymarketOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPolymarketOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPolymarketOpenApiClientUtil, PolymarketOpenApiClientUtil>();

        return services;
    }
}
