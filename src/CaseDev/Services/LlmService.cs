using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Llm;
using CaseDev.Services.Llm;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class LlmService : ILlmService
{
    readonly Lazy<ILlmServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILlmServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ILlmService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LlmService(this._client.WithOptions(modifier));
    }

    public LlmService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LlmServiceWithRawResponse(client.WithRawResponse));
        _v1 = new(() => new V1Service(client));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }

    /// <inheritdoc/>
    public async Task GetConfig(
        LlmGetConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetConfig(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class LlmServiceWithRawResponse : ILlmServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILlmServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LlmServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LlmServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _v1 = new(() => new V1ServiceWithRawResponse(client));
    }

    readonly Lazy<IV1ServiceWithRawResponse> _v1;
    public IV1ServiceWithRawResponse V1
    {
        get { return _v1.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetConfig(
        LlmGetConfigParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LlmGetConfigParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
