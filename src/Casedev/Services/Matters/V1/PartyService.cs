using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.Parties;

namespace Casedev.Services.Matters.V1;

/// <inheritdoc/>
public sealed class PartyService : IPartyService
{
    readonly Lazy<IPartyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPartyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IPartyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PartyService(this._client.WithOptions(modifier));
    }

    public PartyService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PartyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(PartyCreateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Retrieve(
        PartyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Retrieve(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Retrieve(
        string partyID,
        PartyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Retrieve(parameters with { PartyID = partyID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Update(PartyUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string partyID,
        PartyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { PartyID = partyID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(
        PartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PartyServiceWithRawResponse : IPartyServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPartyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PartyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PartyServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        PartyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PartyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        PartyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PartyID == null)
        {
            throw new CasedevInvalidDataException("'parameters.PartyID' cannot be null");
        }

        HttpRequest<PartyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Retrieve(
        string partyID,
        PartyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PartyID = partyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        PartyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PartyID == null)
        {
            throw new CasedevInvalidDataException("'parameters.PartyID' cannot be null");
        }

        HttpRequest<PartyUpdateParams> request = new()
        {
            Method = CasedevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string partyID,
        PartyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PartyID = partyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        PartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PartyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
