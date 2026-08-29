[![](https://img.shields.io/nuget/v/soenneker.blazor.consumer.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.consumer/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.consumer/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.consumer/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.consumer.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.consumer/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.consumer/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.consumer/actions/workflows/codeql.yml)

# Soenneker.Blazor.Consumer

A derivative of Soenneker.Blazor.Consumer.Base, providing instance-wide generic type setting.

## Install

```bash
dotnet add package Soenneker.Blazor.Consumer
```

## Quick start

```csharp
using Soenneker.Blazor.Consumer.Abstract;

IConsumer<TResponse> consumer = /* resolve from DI */;
var result = await consumer.Get("value", default);
```

Retrieves a single resource by ID asynchronously.

## What you get

- `IConsumer<TResponse>` — A derivative of Soenneker.Blazor.Consumer.Base, providing instance-wide generic type setting.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IConsumer<TResponse>.Get(id, overrideUri, allowAnonymous, cancellationToken)` | Retrieves a single resource by ID asynchronously. | An OperationResult containing the response or problem details. |
| `IConsumer<TResponse>.Get(requestOptions, cancellationToken)` | Asynchronously retrieves a response using the specified request options. | A task whose result is the requested operation Result. |
| `IConsumer<TResponse>.GetAll(requestDataOptions, overrideUri, allowAnonymous, cancellationToken)` | Retrieves all resources asynchronously. | An OperationResult containing a list of responses or problem details. |
| `IConsumer<TResponse>.GetAll(requestOptions, cancellationToken)` | Retrieves a paged collection of items that match the specified request options. | A task whose result is the requested operation Result. |
| `IConsumer<TResponse>.Create(request, overrideUri, allowAnonymous, cancellationToken)` | Creates a new resource asynchronously. | An OperationResult containing the created response or problem details. |
| `IConsumer<TResponse>.Create(requestOptions, cancellationToken)` | Creates a new resource asynchronously using the specified request options. | A value task that represents the asynchronous operation. The result contains the outcome of the create operation, including the created resource if successful. |
| `IConsumer<TResponse>.Post(request, overrideUri, allowAnonymous, cancellationToken)` | Sends an HTTP POST request with the specified request payload and returns the operation result asynchronously. | A ValueTask that represents the asynchronous operation. The result contains the response from the server, or an error if the operation fails. |
| `IConsumer<TResponse>.Post(requestOptions, cancellationToken)` | Sends a POST request using the specified options and returns the result asynchronously. | A task whose result is the requested operation Result. |
| `IConsumer<TResponse>.Update(id, request, overrideUri, allowAnonymous, cancellationToken)` | Updates an existing resource asynchronously by ID. | An OperationResult containing the updated response or problem details. |
| `IConsumer<TResponse>.Update(requestOptions, cancellationToken)` | Asynchronously updates the resource using the specified request options. | A task that represents the asynchronous update operation. The task result contains an OperationResult with the response data if the update succeeds. |
| `IConsumer<TResponse>.Put(id, request, overrideUri, allowAnonymous, cancellationToken)` | Sends a PUT request to update or create a resource with the specified identifier and request payload. | A ValueTask that represents the asynchronous operation. The result contains the outcome of the PUT request, including the deserialized response if successful. |
| `IConsumer<TResponse>.Put(requestOptions, cancellationToken)` | Sends a PUT request using the specified options and returns the result asynchronously. | A task whose result is the requested operation Result. |
| `IConsumer<TResponse>.Delete(id, overrideUri, allowAnonymous, cancellationToken)` | Deletes a resource asynchronously by ID. | An OperationResult containing the deleted response or problem details. |
| `IConsumer<TResponse>.Delete(requestOptions, cancellationToken)` | Deletes the resource specified by the request options and returns the result of the operation asynchronously. | A task that represents the asynchronous delete operation. The task result contains an `OperationResult{TResponse}` indicating the outcome of the delete request. |
| `IConsumer<TResponse>.Upload(id, stream, fileName, overrideUri, allowAnonymous, cancellationToken)` | Uploads a file stream asynchronously. | An OperationResult containing the upload response or problem details. |
| `IConsumer<TResponse>.Upload(requestOptions, cancellationToken)` | Initiates an asynchronous file upload operation using the specified upload options. | A value task that represents the asynchronous operation. The result contains an `OperationResult{T}` with a `FileUploadResponse` describing the outcome of the upload. |

## Important behavior

- `IConsumer<TResponse>.Put(id, request, overrideUri, allowAnonymous, cancellationToken)`: If authentication is required and allowAnonymous is false, the request will include authentication credentials. The request payload must be serializable to the expected format (such as JSON).

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
