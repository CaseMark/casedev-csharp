using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1;
using Casedev.Services.Matters.V1;

namespace Casedev.Services.Matters;

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
        _agentTypes = new(() => new AgentTypeService(client));
        _parties = new(() => new PartyService(client));
        _types = new(() => new TypeService(client));
        _events = new(() => new EventService(client));
        _log = new(() => new LogService(client));
        _matterParties = new(() => new MatterPartyService(client));
        _shares = new(() => new ShareService(client));
        _workItems = new(() => new WorkItemService(client));
    }

    readonly Lazy<IAgentTypeService> _agentTypes;
    public IAgentTypeService AgentTypes
    {
        get { return _agentTypes.Value; }
    }

    readonly Lazy<IPartyService> _parties;
    public IPartyService Parties
    {
        get { return _parties.Value; }
    }

    readonly Lazy<ITypeService> _types;
    public ITypeService Types
    {
        get { return _types.Value; }
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<ILogService> _log;
    public ILogService Log
    {
        get { return _log.Value; }
    }

    readonly Lazy<IMatterPartyService> _matterParties;
    public IMatterPartyService MatterParties
    {
        get { return _matterParties.Value; }
    }

    readonly Lazy<IShareService> _shares;
    public IShareService Shares
    {
        get { return _shares.Value; }
    }

    readonly Lazy<IWorkItemService> _workItems;
    public IWorkItemService WorkItems
    {
        get { return _workItems.Value; }
    }

    /// <inheritdoc/>
    public Task Create(V1CreateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Update(V1UpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string id,
        V1UpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(V1ListParams? parameters = null, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
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

        _agentTypes = new(() => new AgentTypeServiceWithRawResponse(client));
        _parties = new(() => new PartyServiceWithRawResponse(client));
        _types = new(() => new TypeServiceWithRawResponse(client));
        _events = new(() => new EventServiceWithRawResponse(client));
        _log = new(() => new LogServiceWithRawResponse(client));
        _matterParties = new(() => new MatterPartyServiceWithRawResponse(client));
        _shares = new(() => new ShareServiceWithRawResponse(client));
        _workItems = new(() => new WorkItemServiceWithRawResponse(client));
    }

    readonly Lazy<IAgentTypeServiceWithRawResponse> _agentTypes;
    public IAgentTypeServiceWithRawResponse AgentTypes
    {
        get { return _agentTypes.Value; }
    }

    readonly Lazy<IPartyServiceWithRawResponse> _parties;
    public IPartyServiceWithRawResponse Parties
    {
        get { return _parties.Value; }
    }

    readonly Lazy<ITypeServiceWithRawResponse> _types;
    public ITypeServiceWithRawResponse Types
    {
        get { return _types.Value; }
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<ILogServiceWithRawResponse> _log;
    public ILogServiceWithRawResponse Log
    {
        get { return _log.Value; }
    }

    readonly Lazy<IMatterPartyServiceWithRawResponse> _matterParties;
    public IMatterPartyServiceWithRawResponse MatterParties
    {
        get { return _matterParties.Value; }
    }

    readonly Lazy<IShareServiceWithRawResponse> _shares;
    public IShareServiceWithRawResponse Shares
    {
        get { return _shares.Value; }
    }

    readonly Lazy<IWorkItemServiceWithRawResponse> _workItems;
    public IWorkItemServiceWithRawResponse WorkItems
    {
        get { return _workItems.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<V1RetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        V1UpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<V1UpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string id,
        V1UpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1ListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        return this._client.Execute(request, cancellationToken);
    }
}
