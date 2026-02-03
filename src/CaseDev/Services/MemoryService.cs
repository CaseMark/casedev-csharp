using System;
using CaseDev.Core;
using CaseDev.Services.Memory;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class MemoryService : IMemoryService
{
    readonly Lazy<IMemoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryService(this._client.WithOptions(modifier));
    }

    public MemoryService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MemoryServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class MemoryServiceWithRawResponse : IMemoryServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
