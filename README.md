# ChuA.SharedKernel

Enterprise-grade reusable shared kernel library for .NET 10 applications.

## Overview

`ChuA.SharedKernel` provides foundational contracts and default implementations that can be shared across ASP.NET Core Web API, MVC, Razor Pages, Blazor Server, worker services, and internal enterprise applications.

The library includes:

- Strongly typed shared-kernel options with validation.
- A single DI startup entry point: `services.AddChuASharedKernel(configuration)`.
- Core abstractions for time, correlation IDs, current users, entities, and domain events.
- Default implementations that are production-safe and easy to replace in tests.
- Result and error models for predictable application outcomes.
- Entity, aggregate root, auditable entity, value object, pagination, exceptions, and guard utilities.

## Architecture

The project follows clean architecture boundaries:

- `Abstractions`: Interface-based contracts consumed by application and domain layers.
- `Configuration`: Options and validation.
- `Constants`: Stable defaults and section names.
- `Extensions`: Application startup and DI registration.
- `Handlers`: Cross-cutting handler contracts.
- `Models`: Results, base entities, value objects, pagination, domain events, and exceptions.
- `Providers`: Default provider implementations.
- `Services`: Default service implementations.
- `Utilities`: Guard clauses and shared helpers.

## Setup

Reference the project or package, then register the shared kernel once during startup.

```csharp
using ChuA.SharedKernel.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddChuASharedKernel(builder.Configuration);

var app = builder.Build();
app.Run();
```

To use a custom configuration section:

```csharp
builder.Services.AddChuASharedKernel(builder.Configuration, "Platform:SharedKernel");
```

## Configuration

Default section name:

```json
{
  "ChuA": {
    "SharedKernel": {
      "ApplicationName": "Contoso.InternalPortal",
      "EnvironmentName": "Production",
      "CorrelationHeaderName": "X-Correlation-ID",
      "EnableDetailedErrors": false,
      "DefaultPageSize": 25,
      "MaxPageSize": 250,
      "ClockKind": "Utc"
    }
  }
}
```

See [sample appsettings](docs/examples/appsettings.SharedKernel.json) and [Program.cs usage](docs/examples/Program.cs).

## Usage Examples

Inject the built-in abstractions from application services, controllers, pages, components, or workers.

```csharp
public sealed class CreateOrderHandler(
    IClock clock,
    ICorrelationIdProvider correlationIdProvider)
{
    public Result Handle()
    {
        var timestamp = clock.Now;
        var correlationId = correlationIdProvider.CorrelationId;

        return Result.Success();
    }
}
```

Return structured failures without throwing for expected business outcomes.

```csharp
return Result<Guid>.Failure(new Error("Orders.NotFound", "The order was not found.", "orderId"));
```

## Extension Points

Applications can replace any default implementation after registration:

```csharp
builder.Services.AddChuASharedKernel(builder.Configuration);
builder.Services.AddScoped<ICurrentUserProvider, HttpContextCurrentUserProvider>();
builder.Services.AddSingleton<IClock, TestClock>();
```

Future additions can plug into the same model: tenant providers, audit stamp services, domain event dispatchers, problem-details mapping, request context middleware, or policy-based validation.

## Build and Test

```powershell
dotnet restore ChuA.SharedKernel.slnx
dotnet build ChuA.SharedKernel.slnx --no-restore
dotnet test ChuA.SharedKernel.slnx --no-build
```
