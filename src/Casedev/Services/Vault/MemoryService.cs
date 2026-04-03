using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Vault.Memory;

namespace Casedev.Services.Vault;

/// <inheritdoc/>
public sealed class MemoryService : IMemoryService
{
    readonly Lazy<IMemoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryService(this._client.WithOptions(modifier));
    }

    public MemoryService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MemoryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MemoryCreateResponse> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MemoryCreateResponse> Create(
        string id,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(MemoryUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string entryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { EntryID = entryID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MemoryListResponse> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MemoryListResponse> List(
        string id,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(MemoryDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string entryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { EntryID = entryID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MemorySearchResponse> Search(
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MemorySearchResponse> Search(
        string id,
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Search(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MemoryServiceWithRawResponse : IMemoryServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryCreateResponse>> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MemoryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var memory = await response
                    .Deserialize<MemoryCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    memory.Validate();
                }
                return memory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MemoryCreateResponse>> Create(
        string id,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntryID == null)
        {
            throw new CasedevInvalidDataException("'parameters.EntryID' cannot be null");
        }

        HttpRequest<MemoryUpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string entryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { EntryID = entryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryListResponse>> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MemoryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var memories = await response
                    .Deserialize<MemoryListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    memories.Validate();
                }
                return memories;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MemoryListResponse>> List(
        string id,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EntryID == null)
        {
            throw new CasedevInvalidDataException("'parameters.EntryID' cannot be null");
        }

        HttpRequest<MemoryDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string entryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { EntryID = entryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemorySearchResponse>> Search(
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MemorySearchParams> request = new()
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
                    .Deserialize<MemorySearchResponse>(token)
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
    public Task<HttpResponse<MemorySearchResponse>> Search(
        string id,
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Search(parameters with { ID = id }, cancellationToken);
    }
}
