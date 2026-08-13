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
    ValueTask<PolymarketOpenApiClient> Get(CancellationToken cancellationToken = default);
}
