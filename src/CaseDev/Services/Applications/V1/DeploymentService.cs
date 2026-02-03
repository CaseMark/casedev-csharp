using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Applications.V1.Deployments;

namespace CaseDev.Services.Applications.V1;

/// <inheritdoc/>
public sealed class DeploymentService : IDeploymentService
{
    readonly Lazy<IDeploymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDeploymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IDeploymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DeploymentService(this._client.WithOptions(modifier));
    }

    public DeploymentService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DeploymentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(DeploymentListParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Cancel(
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Cancel(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Cancel(
        string id,
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Cancel(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task CreateFromFiles(
        DeploymentCreateFromFilesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateFromFiles(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task GetLogs(
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetLogs(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetLogs(
        string id,
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.GetLogs(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task GetStatus(
        DeploymentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetStatus(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task GetStatus(
        string id,
        DeploymentGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.GetStatus(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Stream(
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Stream(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Stream(
        string id,
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Stream(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DeploymentServiceWithRawResponse : IDeploymentServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDeploymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DeploymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DeploymentServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DeploymentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeploymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        DeploymentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DeploymentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Cancel(
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeploymentCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Cancel(
        string id,
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateFromFiles(
        DeploymentCreateFromFilesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DeploymentCreateFromFilesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetLogs(
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeploymentGetLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetLogs(
        string id,
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetLogs(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetStatus(
        DeploymentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeploymentGetStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetStatus(
        string id,
        DeploymentGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatus(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Stream(
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeploymentStreamParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Stream(
        string id,
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Stream(parameters with { ID = id }, cancellationToken);
    }
}
