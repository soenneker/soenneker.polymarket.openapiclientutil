[![](https://img.shields.io/nuget/v/soenneker.polymarket.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.polymarket.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.polymarket.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.polymarket.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.polymarket.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.polymarket.openapiclientutil/)

# Soenneker.Polymarket.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Polymarket.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Polymarket.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddPolymarketOpenApiClientUtilAsSingleton();
```

Adds `PolymarketOpenApiClientUtil` as a singleton service.

## What you get

- `IPolymarketOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `PolymarketOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `PolymarketOpenApiClientUtilRegistrar.AddPolymarketOpenApiClientUtilAsSingleton(services)` | Adds `PolymarketOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `PolymarketOpenApiClientUtilRegistrar.AddPolymarketOpenApiClientUtilAsScoped(services)` | Adds `PolymarketOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
