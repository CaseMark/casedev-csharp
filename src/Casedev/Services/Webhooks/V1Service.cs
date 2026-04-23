using System;
using Casedev.Core;
using Casedev.Services.Webhooks.V1;

namespace Casedev.Services.Webhooks;

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
        _endpoints = new(() => new EndpointService(client));
        _deliveries = new(() => new DeliveryService(client));
        _eventTypes = new(() => new EventTypeService(client));
    }

    readonly Lazy<IEndpointService> _endpoints;
    public IEndpointService Endpoints
    {
        get { return _endpoints.Value; }
    }

    readonly Lazy<IDeliveryService> _deliveries;
    public IDeliveryService Deliveries
    {
        get { return _deliveries.Value; }
    }

    readonly Lazy<IEventTypeService> _eventTypes;
    public IEventTypeService EventTypes
    {
        get { return _eventTypes.Value; }
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

        _endpoints = new(() => new EndpointServiceWithRawResponse(client));
        _deliveries = new(() => new DeliveryServiceWithRawResponse(client));
        _eventTypes = new(() => new EventTypeServiceWithRawResponse(client));
    }

    readonly Lazy<IEndpointServiceWithRawResponse> _endpoints;
    public IEndpointServiceWithRawResponse Endpoints
    {
        get { return _endpoints.Value; }
    }

    readonly Lazy<IDeliveryServiceWithRawResponse> _deliveries;
    public IDeliveryServiceWithRawResponse Deliveries
    {
        get { return _deliveries.Value; }
    }

    readonly Lazy<IEventTypeServiceWithRawResponse> _eventTypes;
    public IEventTypeServiceWithRawResponse EventTypes
    {
        get { return _eventTypes.Value; }
    }
}
