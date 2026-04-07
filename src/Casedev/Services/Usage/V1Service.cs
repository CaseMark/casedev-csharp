using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Usage.V1;
using Casedev.Services.Usage.V1;

namespace Casedev.Services.Usage;

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
        _subscriptions = new(() => new SubscriptionService(client));
    }

    readonly Lazy<ISubscriptionService> _subscriptions;
    public ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    /// <inheritdoc/>
    public Task Retrieve(
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
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

        _subscriptions = new(() => new SubscriptionServiceWithRawResponse(client));
    }

    readonly Lazy<ISubscriptionServiceWithRawResponse> _subscriptions;
    public ISubscriptionServiceWithRawResponse Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1RetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
