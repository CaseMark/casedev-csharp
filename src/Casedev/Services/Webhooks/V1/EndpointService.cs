using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Webhooks.V1.Endpoints;

namespace Casedev.Services.Webhooks.V1;

/// <inheritdoc/>
public sealed class EndpointService : IEndpointService
{
    readonly Lazy<IEndpointServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEndpointServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IEndpointService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EndpointService(this._client.WithOptions(modifier));
    }

    public EndpointService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EndpointServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        EndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(
        EndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        EndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Update(
        EndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string id,
        EndpointUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(
        EndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        EndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        EndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RotateSecret(
        EndpointRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RotateSecret(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RotateSecret(
        string id,
        EndpointRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RotateSecret(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Test(EndpointTestParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Test(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Test(
        string id,
        EndpointTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Test(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EndpointServiceWithRawResponse : IEndpointServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEndpointServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EndpointServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EndpointServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        EndpointCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EndpointCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        EndpointRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EndpointRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        EndpointRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        EndpointUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EndpointUpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string id,
        EndpointUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        EndpointListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EndpointListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EndpointDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EndpointDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        EndpointDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RotateSecret(
        EndpointRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EndpointRotateSecretParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RotateSecret(
        string id,
        EndpointRotateSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateSecret(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Test(
        EndpointTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EndpointTestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Test(
        string id,
        EndpointTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { ID = id }, cancellationToken);
    }
}
