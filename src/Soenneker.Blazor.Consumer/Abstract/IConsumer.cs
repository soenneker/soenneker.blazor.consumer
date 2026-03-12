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
    ValueTask<OperationResult<TResponse>> Get(string? id, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a response using the specified request options.
    /// </summary>
    /// <param name="requestOptions">The options that configure the request, including parameters such as headers, query values, or authentication
    /// settings. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation. The default value is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="OperationResult{TResponse}"/> representing the outcome of the request, including the response data if
    /// successful.</returns>
    [Pure]
    ValueTask<OperationResult<TResponse>> Get(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all resources asynchronously.
    /// </summary>
    /// <param name="requestDataOptions"></param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing a list of responses or problem details.</returns>
    [Pure]
    ValueTask<OperationResult<PagedResult<TResponse>>> GetAll(RequestDataOptions? requestDataOptions = null, string? overrideUri = null,
        bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a paged collection of items that match the specified request options.
    /// </summary>
    /// <param name="requestOptions">The options that define filtering, sorting, and pagination parameters for the query. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an OperationResult with a
    /// PagedResult of items of type TResponse. The result may be empty if no items match the criteria.</returns>
    [Pure]
    ValueTask<OperationResult<PagedResult<TResponse>>> GetAll(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new resource asynchronously.
    /// </summary>
    /// <param name="request">The request object to create the resource.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the created response or problem details.</returns>
    ValueTask<OperationResult<TResponse>> Create(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new resource asynchronously using the specified request options.
    /// </summary>
    /// <param name="requestOptions">The options that configure the creation request. Cannot be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is none.</param>
    /// <returns>A value task that represents the asynchronous operation. The result contains the outcome of the create
    /// operation, including the created resource if successful.</returns>
    ValueTask<OperationResult<TResponse>> Create(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP POST request with the specified request payload and returns the operation result asynchronously.
    /// </summary>
    /// <param name="request">The payload to send in the body of the POST request. Cannot be null.</param>
    /// <param name="overrideUri">An optional URI to override the default endpoint for this request. If null, the default URI is used.</param>
    /// <param name="allowAnonymous">true to allow the request to be sent without authentication; otherwise, false.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask that represents the asynchronous operation. The result contains the response from the server, or an
    /// error if the operation fails.</returns>
    ValueTask<OperationResult<TResponse>> Post(object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a POST request using the specified options and returns the result asynchronously.
    /// </summary>
    /// <param name="requestOptions">The options that configure the POST request, including endpoint, headers, and payload. Cannot be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see
    /// cref="OperationResult{TResponse}"/> representing the outcome of the POST request, including the response data or
    /// error information.</returns>
    ValueTask<OperationResult<TResponse>> Post(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing resource asynchronously by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to update.</param>
    /// <param name="request">The request object to update the resource.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the updated response or problem details.</returns>
    ValueTask<OperationResult<TResponse>> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously updates the resource using the specified request options.
    /// </summary>
    /// <param name="requestOptions">The options that configure the update request. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the update operation.</param>
    /// <returns>A task that represents the asynchronous update operation. The task result contains an OperationResult with the
    /// response data if the update succeeds.</returns>
    ValueTask<OperationResult<TResponse>> Update(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a PUT request to update or create a resource with the specified identifier and request payload.
    /// </summary>
    /// <remarks>If authentication is required and allowAnonymous is false, the request will include
    /// authentication credentials. The request payload must be serializable to the expected format (such as
    /// JSON).</remarks>
    /// <param name="id">The identifier of the resource to update or create. Can be null if the endpoint does not require an identifier.</param>
    /// <param name="request">The payload to send in the PUT request. Must not be null.</param>
    /// <param name="overrideUri">An optional URI to override the default endpoint. If specified, the request is sent to this URI instead of the
    /// standard resource URI.</param>
    /// <param name="allowAnonymous">true to allow the request to be sent without authentication; otherwise, false.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The operation is canceled if the token is triggered.</param>
    /// <returns>A ValueTask that represents the asynchronous operation. The result contains the outcome of the PUT request,
    /// including the deserialized response if successful.</returns>
    ValueTask<OperationResult<TResponse>> Put(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a PUT request using the specified options and returns the result asynchronously.
    /// </summary>
    /// <param name="requestOptions">The options that configure the PUT request, including endpoint, headers, and payload. Cannot be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The operation is canceled if the token is triggered.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an OperationResult{TResponse} with
    /// the response from the PUT request.</returns>
    ValueTask<OperationResult<TResponse>> Put(RequestOptions requestOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a resource asynchronously by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to delete.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An OperationResult containing the deleted response or problem details.</returns>
    ValueTask<OperationResult<TResponse>> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the resource specified by the request options and returns the result of the operation asynchronously.
    /// </summary>
    /// <param name="requestOptions">The options that define which resource to delete and any additional request parameters. Cannot be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous delete operation. The task result contains an <see
    /// cref="OperationResult{TResponse}"/> indicating the outcome of the delete request.</returns>
    ValueTask<OperationResult<TResponse>> Delete(RequestOptions requestOptions, CancellationToken cancellationToken = default);

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
    ValueTask<OperationResult<FileUploadResponse>> Upload(string? id, Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Initiates an asynchronous file upload operation using the specified upload options.
    /// </summary>
    /// <param name="requestOptions">The options that configure the file upload request, including file content, destination, and any additional
    /// upload parameters. Cannot be null.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the upload operation. The default value is <see
    /// cref="CancellationToken.None"/>.</param>
    /// <returns>A value task that represents the asynchronous operation. The result contains an <see cref="OperationResult{T}"/>
    /// with a <see cref="FileUploadResponse"/> describing the outcome of the upload.</returns>
    ValueTask<OperationResult<FileUploadResponse>> Upload(RequestUploadOptions requestOptions, CancellationToken cancellationToken = default);
}