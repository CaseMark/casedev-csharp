using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Services.Matters.V1;

/// <inheritdoc/>
public sealed class WorkItemService : IWorkItemService
{
    readonly Lazy<IWorkItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IWorkItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkItemService(this._client.WithOptions(modifier));
    }

    public WorkItemService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkItemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Create(
        string id,
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Create(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Retrieve(
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string workItemID,
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Retrieve(parameters with { WorkItemID = workItemID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Update(
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string workItemID,
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { WorkItemID = workItemID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(WorkItemListParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task List(
        string id,
        WorkItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.List(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Decide(
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Decide(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Decide(
        string workItemID,
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Decide(parameters with { WorkItemID = workItemID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ListExecutions(
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListExecutions(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task ListExecutions(
        string workItemID,
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.ListExecutions(parameters with { WorkItemID = workItemID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WorkItemServiceWithRawResponse : IWorkItemServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkItemServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WorkItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        string id,
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkItemID == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkItemID' cannot be null");
        }

        HttpRequest<WorkItemRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string workItemID,
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { WorkItemID = workItemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkItemID == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkItemID' cannot be null");
        }

        HttpRequest<WorkItemUpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string workItemID,
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { WorkItemID = workItemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        WorkItemListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WorkItemListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        string id,
        WorkItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Decide(
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkItemID == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkItemID' cannot be null");
        }

        HttpRequest<WorkItemDecideParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Decide(
        string workItemID,
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Decide(parameters with { WorkItemID = workItemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListExecutions(
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkItemID == null)
        {
            throw new CasedevInvalidDataException("'parameters.WorkItemID' cannot be null");
        }

        HttpRequest<WorkItemListExecutionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListExecutions(
        string workItemID,
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListExecutions(parameters with { WorkItemID = workItemID }, cancellationToken);
    }
}
