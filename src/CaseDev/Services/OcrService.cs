using System;
using CaseDev.Core;
using CaseDev.Services.Ocr;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class OcrService : IOcrService
{
    readonly Lazy<IOcrServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOcrServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IOcrService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OcrService(this._client.WithOptions(modifier));
    }

    public OcrService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OcrServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class OcrServiceWithRawResponse : IOcrServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOcrServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OcrServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OcrServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _v1 = new(() => new V1ServiceWithRawResponse(client));
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }
}
