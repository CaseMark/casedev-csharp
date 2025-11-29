using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Voice.V1;
using CaseDev.Services.Voice.V1;

namespace CaseDev.Services.Voice;

/// <inheritdoc />
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
        _speak = new(() => new SpeakService(client));
    }

    readonly Lazy<ISpeakService> _speak;
    public ISpeakService Speak
    {
        get { return _speak.Value; }
    }

    /// <inheritdoc/>
    public async Task ListVoices(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
