using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.AgentTypes;

namespace Casedev.Services.Matters.V1;

/// <inheritdoc/>
public sealed class AgentTypeService : IAgentTypeService
{
    readonly Lazy<IAgentTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IAgentTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentTypeService(this._client.WithOptions(modifier));
    }

    public AgentTypeService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AgentTypeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        AgentTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task List(
        AgentTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AgentTypeServiceWithRawResponse : IAgentTypeServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentTypeServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        AgentTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AgentTypeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        AgentTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
