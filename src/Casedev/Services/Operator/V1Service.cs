using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Operator.V1;

namespace Casedev.Services.Operator;

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
    }

    /// <inheritdoc/>
    public Task Create(V1CreateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task CreateChatCompletion(
        V1CreateChatCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateChatCompletion(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task CreateResponse(
        V1CreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateResponse(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task GetStatus(
        V1GetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.GetStatus(parameters, cancellationToken);
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
    public Task<HttpResponse> CreateChatCompletion(
        V1CreateChatCompletionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1CreateChatCompletionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateResponse(
        V1CreateResponseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1CreateResponseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetStatus(
        V1GetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1GetStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
