using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Superdoc.V1;

namespace Casedev.Services.Superdoc;

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
    public Task<HttpResponse> Annotate(
        V1AnnotateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Annotate(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Convert(
        V1ConvertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Convert(parameters, cancellationToken);
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
    public Task<HttpResponse> Annotate(
        V1AnnotateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1AnnotateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Convert(
        V1ConvertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1ConvertParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
