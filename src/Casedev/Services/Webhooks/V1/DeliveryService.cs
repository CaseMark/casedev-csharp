using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Webhooks.V1.Deliveries;

namespace Casedev.Services.Webhooks.V1;

/// <inheritdoc/>
public sealed class DeliveryService : IDeliveryService
{
    readonly Lazy<IDeliveryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDeliveryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IDeliveryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DeliveryService(this._client.WithOptions(modifier));
    }

    public DeliveryService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DeliveryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Retrieve(
        DeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        DeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(
        DeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Replay(
        DeliveryReplayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Replay(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Replay(
        string id,
        DeliveryReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Replay(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DeliveryServiceWithRawResponse : IDeliveryServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDeliveryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DeliveryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DeliveryServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        DeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeliveryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string id,
        DeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        DeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DeliveryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Replay(
        DeliveryReplayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DeliveryReplayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Replay(
        string id,
        DeliveryReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replay(parameters with { ID = id }, cancellationToken);
    }
}
