using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.Consumer.Abstract;
using Soenneker.Blazor.Consumer.Base;
using Soenneker.Dtos.ProblemDetails;

namespace Soenneker.Blazor.Consumer;

///<inheritdoc cref="IConsumer{TResponse}"/>
public class Consumer<TResponse> : BaseConsumer, IConsumer<TResponse>
{
    protected Consumer(IApiClient apiClient, ILogger<Consumer<TResponse>> logger, string prefixUri) : base(apiClient, logger, prefixUri)
    {
    }

    [Pure]
    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Get(string id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Get<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual Task<(TResponse? response, ProblemDetailsDto? details)> GetTask(string id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetTask<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual ValueTask<(List<TResponse>? response, ProblemDetailsDto? details)> GetAll(string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>(overrideUri, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual Task<(List<TResponse>? response, ProblemDetailsDto? details)> GetAllTask(string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAllTask<TResponse>(overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create(object request, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Create<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update(string id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Update<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete(string id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Upload(Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Upload<TResponse>(stream, fileName, overrideUri, allowAnonymous, cancellationToken);
    }
}