using System;
using CaseDev.Core;
using CaseDev.Services.Convert;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class ConvertService : IConvertService
{
    readonly Lazy<IConvertServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConvertServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IConvertService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConvertService(this._client.WithOptions(modifier));
    }

    public ConvertService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ConvertServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class ConvertServiceWithRawResponse : IConvertServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConvertServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConvertServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConvertServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
