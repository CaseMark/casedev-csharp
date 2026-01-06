using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.Streaming;

namespace CaseDev.Services.Voice;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IStreamingService
{
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
    /// <para>**Pricing:** $0.30 per minute ($18.00 per hour)</para>
    /// </summary>
    Task GetUrl(
        StreamingGetUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
