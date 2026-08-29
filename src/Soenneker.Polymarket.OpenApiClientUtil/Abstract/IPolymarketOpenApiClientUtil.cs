using Soenneker.Polymarket.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Polymarket.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IPolymarketOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured polymarket OpenAPI Client used by the Polymarket OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested polymarket OpenAPI Client.</returns>
    ValueTask<PolymarketOpenApiClient> Get(CancellationToken cancellationToken = default);
}
