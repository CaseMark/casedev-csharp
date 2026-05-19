using System;
using Casedev.Core;
using Agent = Casedev.Services.Agent;

namespace Casedev.Services;

/// <inheritdoc/>
public sealed class AgentService : IAgentService
{
    readonly Lazy<IAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentService(this._client.WithOptions(modifier));
    }

    public AgentService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AgentServiceWithRawResponse(client.WithRawResponse));
        _skills = new(() => new Agent::SkillService(client));
        _v1 = new(() => new Agent::V1Service(client));
    }

    readonly Lazy<Agent::ISkillService> _skills;
    public Agent::ISkillService Skills
    {
        get { return _skills.Value; }
    }

    readonly Lazy<Agent::IV1Service> _v1;
    public Agent::IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class AgentServiceWithRawResponse : IAgentServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _skills = new(() => new Agent::SkillServiceWithRawResponse(client));
        _v1 = new(() => new Agent::V1ServiceWithRawResponse(client));
    }

    readonly Lazy<Agent::ISkillServiceWithRawResponse> _skills;
    public Agent::ISkillServiceWithRawResponse Skills
    {
        get { return _skills.Value; }
    }

    readonly Lazy<Agent::IV1ServiceWithRawResponse> _v1;
    public Agent::IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }
}
