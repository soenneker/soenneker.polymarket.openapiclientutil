using Soenneker.Polymarket.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Polymarket.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached client that routes requests across Polymarket's APIs.
/// </summary>
public interface IPolymarketOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the generated Polymarket client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached Polymarket client.</returns>
    ValueTask<PolymarketOpenApiClient> Get(CancellationToken cancellationToken = default);
}
