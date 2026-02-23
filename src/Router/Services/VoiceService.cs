using System;
using Router.Core;
using Router.Services.Voice;

namespace Router.Services;

/// <inheritdoc/>
public sealed class VoiceService : IVoiceService
{
    readonly Lazy<IVoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceService(this._client.WithOptions(modifier));
    }

    public VoiceService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VoiceServiceWithRawResponse(client.WithRawResponse));
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

/// <inheritdoc/>
public sealed class VoiceServiceWithRawResponse : IVoiceServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoiceServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _streaming = new(() => new StreamingServiceWithRawResponse(client));
        _transcription = new(() => new TranscriptionServiceWithRawResponse(client));
        _v1 = new(() => new V1ServiceWithRawResponse(client));
    }

    readonly Lazy<IStreamingServiceWithRawResponse> _streaming;
    public IStreamingServiceWithRawResponse Streaming
    {
        get { return _streaming.Value; }
    }

    readonly Lazy<ITranscriptionServiceWithRawResponse> _transcription;
    public ITranscriptionServiceWithRawResponse Transcription
    {
        get { return _transcription.Value; }
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }
}
