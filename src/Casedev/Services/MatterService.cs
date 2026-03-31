using System;
using Casedev.Core;
using Casedev.Services.Matters;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class MatterService : IMatterService
{
    readonly Lazy<IMatterServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMatterServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IMatterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MatterService(this._client.WithOptions(modifier));
    }

    public MatterService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MatterServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class MatterServiceWithRawResponse : IMatterServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMatterServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MatterServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MatterServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
