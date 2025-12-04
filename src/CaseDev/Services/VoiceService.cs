using System;
using CaseDev.Core;
using CaseDev.Services.Voice;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class VoiceService : IVoiceService
{
    /// <inheritdoc/>
    public IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public VoiceService(ICasedevClient client)
    {
        _client = client;
        _streaming = new(() => new StreamingService(client));
        _transcription = new(() => new TranscriptionService(client));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IStreamingService> _streaming;
    public IStreamingService Streaming
    {
        get { return _streaming.Value; }
    }

    readonly Lazy<ITranscriptionService> _transcription;
    public ITranscriptionService Transcription
    {
        get { return _transcription.Value; }
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}
