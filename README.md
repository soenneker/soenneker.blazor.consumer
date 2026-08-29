[![](https://img.shields.io/nuget/v/soenneker.blazor.consumer.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.consumer/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.consumer/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.consumer/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.consumer.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.consumer/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.consumer/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.consumer/actions/workflows/codeql.yml)

# Soenneker.Blazor.Consumer

A typed base class for app-specific Blazor API consumers that return `OperationResult<TResponse>` from common CRUD and upload requests.

## Installation

```bash
dotnet add package Soenneker.Blazor.Consumer
```

## Define a consumer

`Consumer<TResponse>` has a protected constructor. Derive a concrete consumer and choose the resource URI prefix once:

```csharp
using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.Consumer;

public sealed class TodoConsumer : Consumer<TodoDto>
{
    public TodoConsumer(
        IApiClient apiClient,
        ILogger<Consumer<TodoDto>> logger,
        IConfiguration configuration)
        : base(apiClient, logger, "todos")
    {
        apiClient.Initialize(
            configuration["Api:BaseUrl"]!,
            requestResponseLogging: false);
    }
}
```

Register the API client and concrete consumer as scoped services:

```csharp
using Soenneker.Blazor.ApiClient.Registrars;

builder.Services.AddApiClientAsScoped();
builder.Services.AddScoped<TodoConsumer>();
```

## Use it

```csharp
OperationResult<TodoDto> result = await todoConsumer.Get(
    id: "42",
    cancellationToken: cancellationToken);

if (result.Succeeded)
{
    TodoDto? todo = result.Value;
}
else
{
    ProblemDetailsDto? problem = result.Problem;
}
```

The generic response type is fixed for `Get`, `Create`, `Post`, `Update`, `Put`, and `Delete`. `GetAll` returns `OperationResult<PagedResult<TodoDto>>`; `Upload` returns `OperationResult<FileUploadResponse>`.

## Default routes

For a prefix of `todos`, the convenience overloads build these relative URIs:

| Call | URI |
| --- | --- |
| `Get("42")`, `Update("42", request)`, `Put("42", request)`, `Delete("42")` | `todos/42` |
| `GetAll()`, `Create(request)`, `Post(request)` | `todos` |
| `Upload("42", stream, "file.pdf")` | `todos/42/upload` |

`overrideUri` replaces the entire default URI. Use the `RequestOptions` overloads when the endpoint does not follow these conventions or when per-request anonymity and logging flags are needed. `allowAnonymous` defaults to `false` for JSON requests.

Responses are deserialized into the success value for successful status codes or into problem details for error responses. A response body that does not match the expected JSON shape produces a failed `OperationResult`; transport, authentication, and cancellation failures may still throw.

Uploads use multipart fields named `file` and `json`. The underlying API client disposes the supplied upload stream after the request, so do not reuse it.
