using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Exceptions;
using CaseDev.Models.Vault;
using CaseDev.Services.Vault;

namespace CaseDev.Services;

/// <inheritdoc/>
public sealed class VaultService : IVaultService
{
    readonly Lazy<IVaultServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVaultServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IVaultService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VaultService(this._client.WithOptions(modifier));
    }

    public VaultService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VaultServiceWithRawResponse(client.WithRawResponse));
        _events = new(() => new EventService(client));
        _graphrag = new(() => new GraphragService(client));
        _groups = new(() => new GroupService(client));
        _multipart = new(() => new MultipartService(client));
        _objects = new(() => new ObjectService(client));
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IGraphragService> _graphrag;
    public IGraphragService Graphrag
    {
        get { return _graphrag.Value; }
    }

    readonly Lazy<IGroupService> _groups;
    public IGroupService Groups
    {
        get { return _groups.Value; }
    }

    readonly Lazy<IMultipartService> _multipart;
    public IMultipartService Multipart
    {
        get { return _multipart.Value; }
    }

    readonly Lazy<IObjectService> _objects;
    public IObjectService Objects
    {
        get { return _objects.Value; }
    }

    /// <inheritdoc/>
    public async Task<VaultCreateResponse> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VaultRetrieveResponse> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultRetrieveResponse> Retrieve(
        string id,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultUpdateResponse> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultUpdateResponse> Update(
        string id,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultListResponse> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VaultDeleteResponse> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultDeleteResponse> Delete(
        string id,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultConfirmUploadResponse> ConfirmUpload(
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ConfirmUpload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultConfirmUploadResponse> ConfirmUpload(
        string objectID,
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ConfirmUpload(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultIngestResponse> Ingest(
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Ingest(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultIngestResponse> Ingest(
        string objectID,
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Ingest(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultSearchResponse> Search(
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultSearchResponse> Search(
        string id,
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Search(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultUploadResponse> Upload(
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VaultUploadResponse> Upload(
        string id,
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VaultServiceWithRawResponse : IVaultServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVaultServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VaultServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VaultServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;

        _events = new(() => new EventServiceWithRawResponse(client));
        _graphrag = new(() => new GraphragServiceWithRawResponse(client));
        _groups = new(() => new GroupServiceWithRawResponse(client));
        _multipart = new(() => new MultipartServiceWithRawResponse(client));
        _objects = new(() => new ObjectServiceWithRawResponse(client));
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IGraphragServiceWithRawResponse> _graphrag;
    public IGraphragServiceWithRawResponse Graphrag
    {
        get { return _graphrag.Value; }
    }

    readonly Lazy<IGroupServiceWithRawResponse> _groups;
    public IGroupServiceWithRawResponse Groups
    {
        get { return _groups.Value; }
    }

    readonly Lazy<IMultipartServiceWithRawResponse> _multipart;
    public IMultipartServiceWithRawResponse Multipart
    {
        get { return _multipart.Value; }
    }

    readonly Lazy<IObjectServiceWithRawResponse> _objects;
    public IObjectServiceWithRawResponse Objects
    {
        get { return _objects.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultCreateResponse>> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VaultCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var vault = await response
                    .Deserialize<VaultCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    vault.Validate();
                }
                return vault;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultRetrieveResponse>> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<VaultRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var vault = await response
                    .Deserialize<VaultRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    vault.Validate();
                }
                return vault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VaultRetrieveResponse>> Retrieve(
        string id,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultUpdateResponse>> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<VaultUpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var vault = await response
                    .Deserialize<VaultUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    vault.Validate();
                }
                return vault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VaultUpdateResponse>> Update(
        string id,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultListResponse>> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VaultListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var vaults = await response
                    .Deserialize<VaultListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    vaults.Validate();
                }
                return vaults;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultDeleteResponse>> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<VaultDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var vault = await response
                    .Deserialize<VaultDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    vault.Validate();
                }
                return vault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VaultDeleteResponse>> Delete(
        string id,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultConfirmUploadResponse>> ConfirmUpload(
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<VaultConfirmUploadParams> request = new()
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
                    .Deserialize<VaultConfirmUploadResponse>(token)
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
    public Task<HttpResponse<VaultConfirmUploadResponse>> ConfirmUpload(
        string objectID,
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ConfirmUpload(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultIngestResponse>> Ingest(
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ObjectID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ObjectID' cannot be null");
        }

        HttpRequest<VaultIngestParams> request = new()
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
                    .Deserialize<VaultIngestResponse>(token)
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
    public Task<HttpResponse<VaultIngestResponse>> Ingest(
        string objectID,
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Ingest(parameters with { ObjectID = objectID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultSearchResponse>> Search(
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<VaultSearchParams> request = new()
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
                    .Deserialize<VaultSearchResponse>(token)
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
    public Task<HttpResponse<VaultSearchResponse>> Search(
        string id,
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Search(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultUploadResponse>> Upload(
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<VaultUploadParams> request = new()
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
                    .Deserialize<VaultUploadResponse>(token)
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
    public Task<HttpResponse<VaultUploadResponse>> Upload(
        string id,
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { ID = id }, cancellationToken);
    }
}
