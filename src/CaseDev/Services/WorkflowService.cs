using System;
using CaseDev.Core;
using CaseDev.Services.Workflows;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class WorkflowService : IWorkflowService
{
    readonly Lazy<IWorkflowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkflowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkflowService(this._client.WithOptions(modifier));
    }

    public WorkflowService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkflowServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class WorkflowServiceWithRawResponse : IWorkflowServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkflowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkflowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkflowServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
