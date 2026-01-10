using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.Streaming;

namespace CaseDev.Services.Voice;

/// <inheritdoc/>
public sealed class StreamingService : IStreamingService
{
    readonly Lazy<IStreamingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStreamingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IStreamingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StreamingService(this._client.WithOptions(modifier));
    }

    public StreamingService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StreamingServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task GetUrl(
        StreamingGetUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class StreamingServiceWithRawResponse : IStreamingServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStreamingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StreamingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StreamingServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetUrl(
        StreamingGetUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StreamingGetUrlParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
