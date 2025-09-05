using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.ApiClient.Dtos;
using Soenneker.Blazor.Consumer.Abstract;
using Soenneker.Blazor.Consumers.Base;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Operation;
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

    public virtual ValueTask<OperationResult<TResponse>?> Get(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetResult<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Get(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return GetResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<PagedResult<TResponse>>?> GetAll(RequestDataOptions? requestDataOptions = null, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAllResult<TResponse>(requestDataOptions, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<PagedResult<TResponse>>?> GetAll(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return GetAllResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Create(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return CreateResult<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Create(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return CreateResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Post(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return PostResult<TResponse>(request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Post(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return PostResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return UpdateResult<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Update(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return UpdateResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Put(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return PutResult<TResponse>(id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Put(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return PutResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return DeleteResult<TResponse>(id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>?> Delete(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return DeleteResult<TResponse>(requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<FileUploadResponse>?> Upload(string? id, Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return UploadResult<FileUploadResponse>(id, stream, fileName, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<FileUploadResponse>?> Upload(RequestUploadOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return UploadResult<FileUploadResponse>(requestOptions, cancellationToken);
    }
}