using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Blazor.Consumer.Base.Abstract;
using Soenneker.Dtos.ProblemDetails;
using Soenneker.Responses.FileUpload;

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
    /// <returns>A tuple containing the response and any problem details.</returns>
    [Pure]
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Get(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a single resource by ID asynchronously using Task.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to retrieve.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the response and any problem details.</returns>
    [Pure]
    Task<(TResponse? response, ProblemDetailsDto? details)> GetTask(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all resources asynchronously.
    /// </summary>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing a list of responses and any problem details.</returns>
    [Pure]
    ValueTask<(List<TResponse>? response, ProblemDetailsDto? details)> GetAll(string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all resources asynchronously using Task.
    /// </summary>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing a list of responses and any problem details.</returns>
    [Pure]
    Task<(List<TResponse>? response, ProblemDetailsDto? details)> GetAllTask(string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new resource asynchronously.
    /// </summary>
    /// <param name="request">The request object to create the resource.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the created response and any problem details.</returns>
    [Pure]
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create(object request, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing resource asynchronously by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to update.</param>
    /// <param name="overrideUri"></param>
    /// <param name="request">The request object to update the resource.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the updated response and any problem details.</returns>
    [Pure]
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update(string? id, object request, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a resource asynchronously by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the resource to delete.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the deleted response and any problem details.</returns>
    [Pure]
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete(string? id, string? overrideUri = null, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a file stream asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="stream">The file stream to upload.</param>
    /// <param name="fileName">The name of the file being uploaded.</param>
    /// <param name="overrideUri"></param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the upload response and any problem details.</returns>
    [Pure]
    ValueTask<(FileUploadResponse? response, ProblemDetailsDto? details)> Upload(string? id, Stream stream, string fileName, string? overrideUri = null, bool allowAnonymous = false,
        CancellationToken cancellationToken = default);
}