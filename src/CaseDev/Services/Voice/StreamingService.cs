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
    /// <inheritdoc/>
    public IStreamingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StreamingService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public StreamingService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task GetURL(
        StreamingGetURLParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StreamingGetURLParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
