using System;
using Casedev.Core;
using Casedev.Services.Worker;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class WorkerService : IWorkerService
{
    readonly Lazy<IWorkerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IWorkerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkerService(this._client.WithOptions(modifier));
    }

    public WorkerService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkerServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class WorkerServiceWithRawResponse : IWorkerServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkerServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
