using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Convert.V1;
using CaseDev.Services.Convert.V1;

namespace CaseDev.Services.Convert;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IJobService Jobs { get; }

    /// <summary>
    /// Download the converted M4A audio file from a completed FTR conversion job.
    /// The file is streamed directly to the client with appropriate headers for
    /// audio playback or download.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Download(
        V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(V1DownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        V1DownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit an FTR (ForensicTech Recording) file for conversion to M4A audio format.
    /// This endpoint is commonly used to convert court recording files into standard
    /// audio formats for transcription or playback. The conversion is processed
    /// asynchronously - you'll receive a job ID to track the conversion status.
    ///
    /// <para>**Supported Input**: FTR files via S3 presigned URLs **Output Format**:
    /// M4A audio **Processing**: Asynchronous with webhook callbacks</para>
    /// </summary>
    Task<V1ProcessResponse> Process(
        V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Internal webhook endpoint that receives completion notifications from the
    /// Modal FTR converter service. This endpoint handles status updates for file
    /// conversion jobs, including success and failure notifications. Requires valid
    /// Bearer token authentication.
    /// </summary>
    Task<V1WebhookResponse> Webhook(
        V1WebhookParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IJobServiceWithRawResponse Jobs { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /convert/v1/download/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Download(V1DownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Download(
        V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(V1DownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        V1DownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /convert/v1/process`, but is otherwise the
    /// same as <see cref="IV1Service.Process(V1ProcessParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ProcessResponse>> Process(
        V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /convert/v1/webhook`, but is otherwise the
    /// same as <see cref="IV1Service.Webhook(V1WebhookParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1WebhookResponse>> Webhook(
        V1WebhookParams parameters,
        CancellationToken cancellationToken = default
    );
}
