using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Voice.V1.Speak;

namespace Casedev.Services.Voice.V1;

/// <inheritdoc/>
public sealed class SpeakService : ISpeakService
{
    readonly Lazy<ISpeakServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpeakServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ISpeakService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeakService(this._client.WithOptions(modifier));
    }

    public SpeakService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SpeakServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        SpeakCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SpeakServiceWithRawResponse : ISpeakServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpeakServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpeakServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpeakServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        SpeakCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SpeakCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
