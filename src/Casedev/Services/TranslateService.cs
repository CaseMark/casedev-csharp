using System;
using Casedev.Core;
using Casedev.Services.Translate;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class TranslateService : ITranslateService
{
    readonly Lazy<ITranslateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITranslateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ITranslateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslateService(this._client.WithOptions(modifier));
    }

    public TranslateService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TranslateServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class TranslateServiceWithRawResponse : ITranslateServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITranslateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TranslateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TranslateServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
