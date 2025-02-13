using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.Consumer.Abstract;
using Soenneker.Blazor.Consumer.Base;
using Soenneker.Dtos.ProblemDetails;
using Soenneker.Responses.FileUpload;

namespace Soenneker.Blazor.Consumer;

///<inheritdoc cref="IConsumer{TResponse}"/>
public class Consumer<TResponse> : BaseConsumer, IConsumer<TResponse>
{
    protected Consumer(IApiClient apiClient, ILogger<Consumer<TResponse>> logger, string prefixUri) : base(apiClient, logger, prefixUri)
    {
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Get(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Get<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(List<TResponse>? response, ProblemDetailsDto? details)> GetAll(string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>(overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create(object request, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Create<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Post(object request, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Post<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Update<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Put(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Put<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(FileUploadResponse? response, ProblemDetailsDto? details)> Upload(string? id, Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Upload<FileUploadResponse>(id, stream, fileName, overrideUri, allowAnonymous, cancellationToken);
    }
}