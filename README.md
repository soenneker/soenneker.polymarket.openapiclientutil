[![](https://img.shields.io/nuget/v/soenneker.polymarket.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.polymarket.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.polymarket.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.polymarket.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.polymarket.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.polymarket.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.polymarket.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.polymarket.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Polymarket.OpenApiClientUtil

Provides a cached generated client with automatic routing across Polymarket's Gamma, Data, CLOB, Bridge, Perpetuals, RFQ, and Relayer APIs.

## Installation

```bash
dotnet add package Soenneker.Polymarket.OpenApiClientUtil
```

## Usage

```csharp
using Soenneker.Polymarket.OpenApiClientUtil.Abstract;
using Soenneker.Polymarket.OpenApiClientUtil.Registrars;

services.AddPolymarketOpenApiClientUtilAsSingleton();

IPolymarketOpenApiClientUtil polymarket = serviceProvider
    .GetRequiredService<IPolymarketOpenApiClientUtil>();

var client = await polymarket.Get(cancellationToken);
var events = await client.Gamma.Events.GetAsync(
    request => request.QueryParameters.Limit = 5,
    cancellationToken);
```

The source-API segment in each generated path selects the destination host and is removed before transmission. The same client can therefore call `client.Data`, `client.Clob`, `client.Bridge`, `client.Perps`, `client.CombosRfq`, and `client.Relayer` without changing its base address.

Override hosts with `Polymarket:BaseUrls:Gamma`, `Data`, `Clob`, `Bridge`, `Perps`, `CombosRfq`, or `Relayer`. Public market-data calls require no credentials; private trading and relayer calls still require the headers and signatures defined by Polymarket.

Use `AddPolymarketOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The routing HTTP provider remains shared and is disposed by the service container at shutdown.
