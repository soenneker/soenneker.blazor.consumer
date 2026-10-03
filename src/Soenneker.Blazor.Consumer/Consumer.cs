using Microsoft.Extensions.Logging;
using Soenneker.Blazor.ApiClient.Abstract;
using Soenneker.Blazor.ApiClient.Dtos;
using Soenneker.Blazor.Consumer.Abstract;
using Soenneker.Blazor.Consumers.Base;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Operation;
using Soenneker.Dtos.Results.Paged;
using Soenneker.Responses.FileUpload;
using System;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Consumer;


public class Consumer<TResponse> : BaseConsumer, IConsumer<TResponse>
{
    private readonly JsonSerializerContext _jsonContext;
    private JsonTypeInfo<TResponse>? _responseTypeInfo;
    private JsonTypeInfo<PagedResult<TResponse>>? _pagedTypeInfo;
    private JsonTypeInfo<FileUploadResponse>? _uploadTypeInfo;

    protected Consumer(IApiClient apiClient, ILogger<Consumer<TResponse>> logger, string prefixUri, JsonSerializerContext jsonContext) : base(apiClient, logger, prefixUri)
    {
        _jsonContext = jsonContext ?? throw new ArgumentNullException(nameof(jsonContext));
    }

    private JsonTypeInfo<T> GetTypeInfo<T>() =>
        (JsonTypeInfo<T>)(_jsonContext.GetTypeInfo(typeof(T)) ?? throw new NotSupportedException($"No generated JSON metadata for {typeof(T)}."));

    public virtual ValueTask<OperationResult<TResponse>> Get(string? id, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Get<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Get(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Get<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<PagedResult<TResponse>>> GetAll(RequestDataOptions? requestDataOptions = null, string? overrideUri = null,
        bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>((_pagedTypeInfo ??= GetTypeInfo<PagedResult<TResponse>>()), requestDataOptions, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<PagedResult<TResponse>>> GetAll(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return GetAll<TResponse>((_pagedTypeInfo ??= GetTypeInfo<PagedResult<TResponse>>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Create(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Create<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Create(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Create<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Post(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Post<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Post(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Post<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Update<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Update(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Update<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Put(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Put<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), id, request, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Put(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Put<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), id, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<TResponse>> Delete(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Delete<TResponse>((_responseTypeInfo ??= GetTypeInfo<TResponse>()), requestOptions, cancellationToken);
    }

    public virtual ValueTask<OperationResult<FileUploadResponse>> Upload(string? id, Stream stream, string fileName, string? overrideUri = null,
        bool allowAnonymous = false, CancellationToken cancellationToken = default)
    {
        return Upload<FileUploadResponse>((_uploadTypeInfo ??= GetTypeInfo<FileUploadResponse>()), id, stream, fileName, overrideUri, allowAnonymous, cancellationToken);
    }

    public virtual ValueTask<OperationResult<FileUploadResponse>> Upload(RequestUploadOptions requestOptions, CancellationToken cancellationToken = default)
    {
        return Upload<FileUploadResponse>((_uploadTypeInfo ??= GetTypeInfo<FileUploadResponse>()), requestOptions, cancellationToken);
    }
}
