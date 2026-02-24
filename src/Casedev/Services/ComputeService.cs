using System;
using Casedev.Core;
using Casedev.Services.Compute;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class ComputeService : IComputeService
{
    readonly Lazy<IComputeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IComputeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IComputeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComputeService(this._client.WithOptions(modifier));
    }

    public ComputeService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ComputeServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class ComputeServiceWithRawResponse : IComputeServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IComputeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComputeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ComputeServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
