using System;
using Router.Core;
using Router.Services.Legal;

namespace Router.Services;

/// <inheritdoc/>
public sealed class LegalService : ILegalService
{
    readonly Lazy<ILegalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILegalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ILegalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LegalService(this._client.WithOptions(modifier));
    }

    public LegalService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LegalServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class LegalServiceWithRawResponse : ILegalServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILegalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LegalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LegalServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
