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
    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Get(string id, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Get<TResponse>(id, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual Task<(TResponse? response, ProblemDetailsDto? details)> GetTask(string id, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetTask<TResponse>(id, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual ValueTask<(List<TResponse>? response, ProblemDetailsDto? details)> GetAll(bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>(allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual Task<(List<TResponse>? response, ProblemDetailsDto? details)> GetAllTask(bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAllTask<TResponse>(allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create(object request, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Create<TResponse>(request, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update(string id, object request, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Update<TResponse>(id, request, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete(string id, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>(id, allowAnonymous, cancellationToken);
    }

    [Pure]
    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Upload(Stream stream, string fileName, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Upload<TResponse>(stream, fileName, allowAnonymous, cancellationToken);
    }
}