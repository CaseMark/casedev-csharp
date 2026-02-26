using System;
using Casedev.Core;
using V1 = Casedev.Services.Agent.V1;

namespace Casedev.Services.Agent;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    public V1Service(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1ServiceWithRawResponse(client.WithRawResponse));
        _agents = new(() => new V1::AgentService(client));
        _run = new(() => new V1::RunService(client));
        _execute = new(() => new V1::ExecuteService(client));
    }

    readonly Lazy<V1::IAgentService> _agents;
    public V1::IAgentService Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<V1::IRunService> _run;
    public V1::IRunService Run
    {
        get { return _run.Value; }
    }

    readonly Lazy<V1::IExecuteService> _execute;
    public V1::IExecuteService Execute
    {
        get { return _execute.Value; }
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1ServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _agents = new(() => new V1::AgentServiceWithRawResponse(client));
        _run = new(() => new V1::RunServiceWithRawResponse(client));
        _execute = new(() => new V1::ExecuteServiceWithRawResponse(client));
    }

    readonly Lazy<V1::IAgentServiceWithRawResponse> _agents;
    public V1::IAgentServiceWithRawResponse Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<V1::IRunServiceWithRawResponse> _run;
    public V1::IRunServiceWithRawResponse Run
    {
        get { return _run.Value; }
    }

    readonly Lazy<V1::IExecuteServiceWithRawResponse> _execute;
    public V1::IExecuteServiceWithRawResponse Execute
    {
        get { return _execute.Value; }
    }
}
