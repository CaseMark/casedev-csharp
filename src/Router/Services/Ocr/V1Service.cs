using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Router.Core;
using Router.Exceptions;
using V1 = Router.Models.Ocr.V1;

namespace Router.Services.Ocr;

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
    public async Task<V1::V1RetrieveResponse> Retrieve(
        V1::V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<V1::V1RetrieveResponse> Retrieve(
        string id,
        V1::V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Download(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        ApiEnum<string, V1::Type> type,
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<V1::V1ProcessResponse> Process(
        V1::V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Process(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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
    public async Task<HttpResponse<V1::V1RetrieveResponse>> Retrieve(
        V1::V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<V1::V1RetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var v1 = await response
                    .Deserialize<V1::V1RetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    v1.Validate();
                }
                return v1;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<V1::V1RetrieveResponse>> Retrieve(
        string id,
        V1::V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Type == null)
        {
            throw new CasedevInvalidDataException("'parameters.Type' cannot be null");
        }

        HttpRequest<V1::V1DownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        ApiEnum<string, V1::Type> type,
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<V1::V1ProcessResponse>> Process(
        V1::V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1::V1ProcessParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<V1::V1ProcessResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
