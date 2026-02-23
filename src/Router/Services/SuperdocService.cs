using System;
using Router.Core;
using Router.Services.Superdoc;

namespace Router.Services;

/// <inheritdoc/>
public sealed class SuperdocService : ISuperdocService
{
    readonly Lazy<ISuperdocServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISuperdocServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISuperdocService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SuperdocService(this._client.WithOptions(modifier));
    }

    public SuperdocService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SuperdocServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class SuperdocServiceWithRawResponse : ISuperdocServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISuperdocServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SuperdocServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SuperdocServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
