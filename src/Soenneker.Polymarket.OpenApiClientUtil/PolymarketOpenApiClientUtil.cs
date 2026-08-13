using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Polymarket.HttpClients.Abstract;
using Soenneker.Polymarket.OpenApiClientUtil.Abstract;
using Soenneker.Polymarket.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Polymarket.OpenApiClientUtil;

///<inheritdoc cref="IPolymarketOpenApiClientUtil"/>
public sealed class PolymarketOpenApiClientUtil : IPolymarketOpenApiClientUtil
{
    private readonly AsyncSingleton<PolymarketOpenApiClient> _client;

    public PolymarketOpenApiClientUtil(IPolymarketOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<PolymarketOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new PolymarketOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<PolymarketOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
