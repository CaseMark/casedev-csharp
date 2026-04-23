using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Webhooks.V1.EventTypes;

namespace Casedev.Services.Webhooks.V1;

/// <inheritdoc/>
public sealed class EventTypeService : IEventTypeService
{
    readonly Lazy<IEventTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IEventTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventTypeService(this._client.WithOptions(modifier));
    }

    public EventTypeService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventTypeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task List(
        EventTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EventTypeServiceWithRawResponse : IEventTypeServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventTypeServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        EventTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EventTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
