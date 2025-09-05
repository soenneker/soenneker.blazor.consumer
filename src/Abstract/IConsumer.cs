using Soenneker.Blazor.ApiClient.Dtos;
using Soenneker.Blazor.Consumers.Base.Abstract;
using Soenneker.Dtos.RequestDataOptions;
using Soenneker.Dtos.Results.Operation;
using Soenneker.Dtos.Results.Paged;
using Soenneker.Responses.FileUpload;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.Consumer.Abstract;

/// <summary>
/// A derivative of Soenneker.Blazor.Consumer.Base, providing instance-wide generic type setting.
/// </summary>
public interface IConsumer<TResponse> : IBaseConsumer
{
    /// <summary>
    /// Retrieves a single resource by ID asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to retrieve.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the response or problem details.</returns>
    [Pure]
    ValueTask<OperationResult<TResponse>?> Get(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    [Pure]
    ValueTask<OperationResult<TResponse>?> Get(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all resources asynchronously.
    /// </summary>
    /// <param name="requestDataOptions"></param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing a list of responses or problem details.</returns>
    [Pure]
    ValueTask<OperationResult<PagedResult<TResponse>>?> GetAll(RequestDataOptions? requestDataOptions = null, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    [Pure]
    ValueTask<OperationResult<PagedResult<TResponse>>?> GetAll(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new resource asynchronously.
    /// </summary>
    /// <param name="request">The request object to create the resource.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the created response or problem details.</returns>
    ValueTask<OperationResult<TResponse>?> Create(object request, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Create(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Post(object request, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Post(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing resource asynchronously by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to update.</param>
    /// <param name="request">The request object to update the resource.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the updated response or problem details.</returns>
    ValueTask<OperationResult<TResponse>?> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Update(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Put(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Put(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a resource asynchronously by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to delete.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the deleted response or problem details.</returns>
    ValueTask<OperationResult<TResponse>?> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    ValueTask<OperationResult<TResponse>?> Delete(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a file stream asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="stream">The file stream to upload.</param>
    /// <param name="fileName">The name of the file being uploaded.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the upload response or problem details.</returns>
    ValueTask<OperationResult<FileUploadResponse>?> Upload(string? id, Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    ValueTask<OperationResult<FileUploadResponse>?> Upload(RequestUploadOptions requestOptions, CancellationToken cancellationToken = default);
}