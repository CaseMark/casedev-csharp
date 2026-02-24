using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Voice.Streaming;

namespace Casedev.Services.Voice;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IStreamingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStreamingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStreamingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns the WebSocket URL and connection details for real-time audio transcription.
    /// The returned URL can be used to establish a WebSocket connection for streaming
    /// audio data and receiving transcribed text in real-time.
    ///
    /// <para>**Audio Requirements:** - Sample Rate: 16kHz - Encoding: PCM 16-bit
    /// little-endian - Channels: Mono (1 channel)</para>
    ///
    /// <para>**Pricing:** $0.01 per minute ($0.60 per hour)</para>
    /// </summary>
    Task<StreamingGetUrlResponse> GetUrl(
        StreamingGetUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IStreamingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStreamingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStreamingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /voice/streaming/url`, but is otherwise the
    /// same as <see cref="IStreamingService.GetUrl(StreamingGetUrlParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StreamingGetUrlResponse>> GetUrl(
        StreamingGetUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
