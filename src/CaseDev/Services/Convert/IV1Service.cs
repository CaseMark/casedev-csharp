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
