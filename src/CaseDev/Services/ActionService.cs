using System;
using CaseDev.Core;
using CaseDev.Services.Actions;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class ActionService : IActionService
{
    readonly Lazy<IActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ActionService(this._client.WithOptions(modifier));
    }

    public ActionService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ActionServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class ActionServiceWithRawResponse : IActionServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
