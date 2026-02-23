using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Router.Core;
using Router.Exceptions;
using Router.Models.Applications.V1.Workflows;

namespace Router.Services.Applications.V1;

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
    }

    /// <inheritdoc/>
    public Task GetStatus(
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetStatus(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetStatus(
        string id,
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.GetStatus(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
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
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetStatus(
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WorkflowGetStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetStatus(
        string id,
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { ID = id }, cancellationToken);
    }
}
