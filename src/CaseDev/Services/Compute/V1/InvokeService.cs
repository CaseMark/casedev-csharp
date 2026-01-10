using System;
using CaseDev.Core;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class InvokeService : IInvokeService
{
    readonly Lazy<IInvokeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvokeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvokeService(this._client.WithOptions(modifier));
    }

    public InvokeService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvokeServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class InvokeServiceWithRawResponse : IInvokeServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvokeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvokeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvokeServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }
}
