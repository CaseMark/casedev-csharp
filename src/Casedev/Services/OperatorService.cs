using System;
using Casedev.Core;
using Casedev.Services.Operator;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class OperatorService : IOperatorService
{
    readonly Lazy<IOperatorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOperatorServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IOperatorService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OperatorService(this._client.WithOptions(modifier));
    }

    public OperatorService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OperatorServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class OperatorServiceWithRawResponse : IOperatorServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOperatorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OperatorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OperatorServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
