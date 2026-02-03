using System;
using CaseDev.Core;
using CaseDev.Services.Projects;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class ProjectService : IProjectService
{
    readonly Lazy<IProjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectService(this._client.WithOptions(modifier));
    }

    public ProjectService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProjectServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }
}

/// <inheritdoc/>
public sealed class ProjectServiceWithRawResponse : IProjectServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProjectServiceWithRawResponse(ICasedevClientWithRawResponse client)
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
