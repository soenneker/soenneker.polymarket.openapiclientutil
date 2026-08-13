using Soenneker.Polymarket.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Polymarket.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PolymarketOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IPolymarketOpenApiClientUtil _openapiclientutil;

    public PolymarketOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IPolymarketOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
