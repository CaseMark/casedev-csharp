using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Llm.V1;
using CaseDev.Services.Llm.V1;

namespace CaseDev.Services.Llm;

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
        _chat = new(() => new ChatService(client));
    }

    readonly Lazy<IChatService> _chat;
    public IChatService Chat
    {
        get { return _chat.Value; }
    }

    /// <inheritdoc/>
    public Task CreateEmbedding(
        V1CreateEmbeddingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.CreateEmbedding(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task ListModels(
        V1ListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListModels(parameters, cancellationToken);
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

        _chat = new(() => new ChatServiceWithRawResponse(client));
    }

    readonly Lazy<IChatServiceWithRawResponse> _chat;
    public IChatServiceWithRawResponse Chat
    {
        get { return _chat.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> CreateEmbedding(
        V1CreateEmbeddingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateEmbeddingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListModels(
        V1ListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V1ListModelsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
