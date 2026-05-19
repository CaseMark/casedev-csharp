using System;
using Casedev.Core;
using Casedev.Services.Agent.Skills;

namespace Casedev.Services.Agent;

/// <inheritdoc/>
public sealed class SkillService : ISkillService
{
    readonly Lazy<ISkillServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISkillServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillService(this._client.WithOptions(modifier));
    }

    public SkillService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SkillServiceWithRawResponse(client.WithRawResponse));
        _namespaces = new(() => new NamespaceService(client));
    }

    readonly Lazy<INamespaceService> _namespaces;
    public INamespaceService Namespaces
    {
        get { return _namespaces.Value; }
    }
}

/// <inheritdoc/>
public sealed class SkillServiceWithRawResponse : ISkillServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISkillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SkillServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _namespaces = new(() => new NamespaceServiceWithRawResponse(client));
    }

    readonly Lazy<INamespaceServiceWithRawResponse> _namespaces;
    public INamespaceServiceWithRawResponse Namespaces
    {
        get { return _namespaces.Value; }
    }
}
