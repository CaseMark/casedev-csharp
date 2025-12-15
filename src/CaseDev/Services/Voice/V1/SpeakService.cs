using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.V1.Speak;

namespace CaseDev.Services.Voice.V1;

/// <inheritdoc/>
public sealed class SpeakService : ISpeakService
{
    /// <inheritdoc/>
    public ISpeakService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeakService(this._client.WithOptions(modifier));
    }

    readonly ICasedevClient _client;

    public SpeakService(ICasedevClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Create(
        SpeakCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SpeakCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return response;
    }
}
