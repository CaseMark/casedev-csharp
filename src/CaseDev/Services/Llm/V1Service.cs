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
    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public V1Service(ICasedevClient client)
    {
        _client = client;
        _chat = new(() => new ChatService(client));
    }

    readonly Lazy<IChatService> _chat;
    public IChatService Chat
    {
        get { return _chat.Value; }
    }

    /// <inheritdoc/>
    public async Task CreateEmbedding(
        V1CreateEmbeddingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateEmbeddingParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task ListModels(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
