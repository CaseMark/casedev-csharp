using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.V1;
using CaseDev.Services.Voice.V1;

namespace CaseDev.Services.Voice;

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
        _speak = new(() => new SpeakService(client));
    }

    readonly Lazy<ISpeakService> _speak;
    public ISpeakService Speak
    {
        get { return _speak.Value; }
    }

    /// <inheritdoc/>
    public Task ListVoices(
        V1ListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListVoices(parameters, cancellationToken);
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

        _speak = new(() => new SpeakServiceWithRawResponse(client));
    }

    readonly Lazy<ISpeakServiceWithRawResponse> _speak;
    public ISpeakServiceWithRawResponse Speak
    {
        get { return _speak.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListVoices(
        V1ListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1ListVoicesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
