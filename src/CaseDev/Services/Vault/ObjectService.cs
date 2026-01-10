using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault.Objects;

namespace CaseDev.Services.Vault;

/// <inheritdoc/>
public sealed class ObjectService : IObjectService
{
    readonly Lazy<IObjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IObjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IObjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ObjectService(this._client.WithOptions(modifier));
    }

    public ObjectService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ObjectServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string objectID,
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Retrieve(parameters with { ObjectID = objectID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task List(
        ObjectListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task List(
        string id,
        ObjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.List(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ObjectCreatePresignedUrlResponse> CreatePresignedUrl(
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreatePresignedUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ObjectCreatePresignedUrlResponse> CreatePresignedUrl(
        string objectID,
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePresignedUrl(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Download(
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Download(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Download(
        string objectID,
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Download(parameters with { ObjectID = objectID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task GetText(
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetText(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task GetText(
        string objectID,
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.GetText(parameters with { ObjectID = objectID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ObjectServiceWithRawResponse : IObjectServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IObjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ObjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ObjectServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<ObjectRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string objectID,
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        ObjectListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ObjectListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        string id,
        ObjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ObjectCreatePresignedUrlResponse>> CreatePresignedUrl(
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<ObjectCreatePresignedUrlParams> request = new()
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
                    .Deserialize<ObjectCreatePresignedUrlResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ObjectCreatePresignedUrlResponse>> CreatePresignedUrl(
        string objectID,
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePresignedUrl(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<ObjectDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string objectID,
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetText(
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<ObjectGetTextParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> GetText(
        string objectID,
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetText(parameters with { ObjectID = objectID }, cancellationToken);
    }
}
