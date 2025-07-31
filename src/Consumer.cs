using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.ApiClient.Dtos;
using Soenneker.Blazor.Consumer.Abstract;
using Soenneker.Blazor.Consumers.Base;
using Soenneker.Dtos.ProblemDetails;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Paged;
using Soenneker.Responses.FileUpload;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Get(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Get<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(PagedResult<TResponse>? response, ProblemDetailsDto? details)> GetAll(RequestDataOptions? requestDataOptions = null, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>(requestDataOptions, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(PagedResult<TResponse>? response, ProblemDetailsDto? details)> GetAll(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Create<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Create<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Post(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Post<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Post(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Post<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Update<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Update<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Put(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Put<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Put(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Put<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<(FileUploadResponse? response, ProblemDetailsDto? details)> Upload(string? id, Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Upload<FileUploadResponse>(id, stream, fileName, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<(FileUploadResponse? response, ProblemDetailsDto? details)> Upload(RequestUploadOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Upload<FileUploadResponse>(requestOptions, cancellationToken);
    }
}