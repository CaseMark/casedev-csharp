using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Vault.Multipart;

namespace CaseDev.Services.Vault;

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
    /// Abort a multipart upload and discard uploaded parts.
    /// </summary>
    Task Abort(MultipartAbortParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Abort(MultipartAbortParams, CancellationToken)"/>
    Task Abort(
        string id,
        MultipartAbortParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Complete a multipart upload by providing the list of part numbers and ETags.
    /// </summary>
    Task Complete(
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(MultipartCompleteParams, CancellationToken)"/>
    Task Complete(
        string id,
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate presigned URLs for individual multipart upload parts.
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

    /// <summary>
    /// Initiate a multipart upload for large files (>5GB). Returns an uploadId and
    /// object metadata. Use part URLs endpoint to upload parts and complete endpoint
    /// to finalize.
    /// </summary>
    Task<MultipartInitResponse> Init(
        MultipartInitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Init(MultipartInitParams, CancellationToken)"/>
    Task<MultipartInitResponse> Init(
        string id,
        MultipartInitParams parameters,
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
    /// Returns a raw HTTP response for `post /vault/{id}/multipart/complete`, but is otherwise the
    /// same as <see cref="IMultipartService.Complete(MultipartCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Complete(
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(MultipartCompleteParams, CancellationToken)"/>
    Task<HttpResponse> Complete(
        string id,
        MultipartCompleteParams parameters,
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

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/multipart/init`, but is otherwise the
    /// same as <see cref="IMultipartService.Init(MultipartInitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MultipartInitResponse>> Init(
        MultipartInitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Init(MultipartInitParams, CancellationToken)"/>
    Task<HttpResponse<MultipartInitResponse>> Init(
        string id,
        MultipartInitParams parameters,
        CancellationToken cancellationToken = default
    );
}
