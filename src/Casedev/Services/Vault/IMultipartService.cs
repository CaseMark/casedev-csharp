using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Vault.Multipart;

namespace Casedev.Services.Vault;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMultipartService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMultipartServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMultipartService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Abort a multipart upload and discard uploaded parts (live).
    /// </summary>
    Task Abort(MultipartAbortParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Abort(MultipartAbortParams, CancellationToken)"/>
    Task Abort(
        string id,
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate presigned URLs for individual multipart upload parts (live).
    /// </summary>
    Task<MultipartGetPartUrlsResponse> GetPartUrls(
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPartUrls(MultipartGetPartUrlsParams, CancellationToken)"/>
    Task<MultipartGetPartUrlsResponse> GetPartUrls(
        string id,
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMultipartService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMultipartServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMultipartServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/multipart/abort`, but is otherwise the
    /// same as <see cref="IMultipartService.Abort(MultipartAbortParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Abort(
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Abort(MultipartAbortParams, CancellationToken)"/>
    Task<HttpResponse> Abort(
        string id,
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/multipart/part-urls`, but is otherwise the
    /// same as <see cref="IMultipartService.GetPartUrls(MultipartGetPartUrlsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MultipartGetPartUrlsResponse>> GetPartUrls(
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPartUrls(MultipartGetPartUrlsParams, CancellationToken)"/>
    Task<HttpResponse<MultipartGetPartUrlsResponse>> GetPartUrls(
        string id,
        MultipartGetPartUrlsParams parameters,
        CancellationToken cancellationToken = default
    );
}
