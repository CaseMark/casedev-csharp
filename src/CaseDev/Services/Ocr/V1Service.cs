using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using V1 = CaseDev.Models.Ocr.V1;

namespace CaseDev.Services.Ocr;

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
    }

    /// <inheritdoc/>
    public async Task Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string id,
        V1::V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Download(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Download(
        ApiEnum<string, V1::Type> type,
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Download(parameters with { Type = type }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<V1::V1ProcessResponse> Process(
        V1::V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1::V1ProcessParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<V1::V1ProcessResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
