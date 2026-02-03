using System;
using CaseDev.Core;
using V1 = CaseDev.Services.Database.V1;

namespace CaseDev.Services.Database;

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
        _projects = new(() => new V1::ProjectService(client));
    }

    readonly Lazy<V1::IProjectService> _projects;
    public V1::IProjectService Projects
    {
        get { return _projects.Value; }
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

        _projects = new(() => new V1::ProjectServiceWithRawResponse(client));
    }

    readonly Lazy<V1::IProjectServiceWithRawResponse> _projects;
    public V1::IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }
}
