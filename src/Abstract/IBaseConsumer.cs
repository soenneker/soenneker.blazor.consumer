using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dtos.ProblemDetails;

namespace Soenneker.Blazor.Consumer.Abstract;

/// <summary>
/// An abstract wrapper around Soenneker.Blazor.ApiClient supporting auto (de)serialization for requests/responses/ProblemDetails.
/// </summary>
public interface IBaseConsumer
{
    /// <summary>
    /// Retrieves a single resource by ID asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="id">The unique identifier of the resource to retrieve.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the response and any problem details.</returns>
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Get<TResponse>(string id, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a single resource by ID asynchronously using Task.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="id">The unique identifier of the resource to retrieve.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the response and any problem details.</returns>
    Task<(TResponse? response, ProblemDetailsDto? details)> GetTask<TResponse>(string id, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all resources asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing a list of responses and any problem details.</returns>
    ValueTask<(List<TResponse>? response, ProblemDetailsDto? details)> GetAll<TResponse>(bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all resources asynchronously using Task.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing a list of responses and any problem details.</returns>
    Task<(List<TResponse>? response, ProblemDetailsDto? details)> GetAllTask<TResponse>(bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new resource asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="request">The request object to create the resource.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the created response and any problem details.</returns>
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Create<TResponse>(object request, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing resource asynchronously by ID.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="id">The unique identifier of the resource to update.</param>
    /// <param name="request">The request object to update the resource.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the updated response and any problem details.</returns>
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Update<TResponse>(string id, object request, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a resource asynchronously by ID.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="id">The unique identifier of the resource to delete.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the deleted response and any problem details.</returns>
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Delete<TResponse>(string id, bool allowAnonymous = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a file stream asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected.</typeparam>
    /// <param name="stream">The file stream to upload.</param>
    /// <param name="fileName">The name of the file being uploaded.</param>
    /// <param name="allowAnonymous">Indicates whether anonymous access is allowed.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A tuple containing the upload response and any problem details.</returns>
    ValueTask<(TResponse? response, ProblemDetailsDto? details)> Upload<TResponse>(Stream stream, string fileName, bool allowAnonymous = false, CancellationToken cancellationToken = default);
}