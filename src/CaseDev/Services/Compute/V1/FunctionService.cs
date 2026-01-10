using System;
using CaseDev.Core;

namespace CaseDev.Services.Compute.V1;

/// <inheritdoc/>
public sealed class FunctionService : IFunctionService
{
    readonly Lazy<IFunctionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFunctionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionService(this._client.WithOptions(modifier));
    }

    public FunctionService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FunctionServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class FunctionServiceWithRawResponse : IFunctionServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFunctionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FunctionServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }
}
