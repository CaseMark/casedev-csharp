using System;
using Casedev.Core;
using Casedev.Services.Agent.V2;

namespace Casedev.Services.Agent;

/// <inheritdoc/>
public sealed class V2Service : IV2Service
{
    readonly Lazy<IV2ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV2ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IV2Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2Service(this._client.WithOptions(modifier));
    }

    public V2Service(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V2ServiceWithRawResponse(client.WithRawResponse));
        _run = new(() => new RunService(client));
        _execute = new(() => new ExecuteService(client));
        _chat = new(() => new ChatService(client));
    }

    readonly Lazy<IRunService> _run;
    public IRunService Run
    {
        get { return _run.Value; }
    }

    readonly Lazy<IExecuteService> _execute;
    public IExecuteService Execute
    {
        get { return _execute.Value; }
    }

    readonly Lazy<IChatService> _chat;
    public IChatService Chat
    {
        get { return _chat.Value; }
    }
}

/// <inheritdoc/>
public sealed class V2ServiceWithRawResponse : IV2ServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV2ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V2ServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _run = new(() => new RunServiceWithRawResponse(client));
        _execute = new(() => new ExecuteServiceWithRawResponse(client));
        _chat = new(() => new ChatServiceWithRawResponse(client));
    }

    readonly Lazy<IRunServiceWithRawResponse> _run;
    public IRunServiceWithRawResponse Run
    {
        get { return _run.Value; }
    }

    readonly Lazy<IExecuteServiceWithRawResponse> _execute;
    public IExecuteServiceWithRawResponse Execute
    {
        get { return _execute.Value; }
    }

    readonly Lazy<IChatServiceWithRawResponse> _chat;
    public IChatServiceWithRawResponse Chat
    {
        get { return _chat.Value; }
    }
}
