using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Exceptions;
using Casedev.Models.Matters.V1.MatterParties;

namespace Casedev.Services.Matters.V1;

/// <inheritdoc/>
public sealed class MatterPartyService : IMatterPartyService
{
    readonly Lazy<IMatterPartyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMatterPartyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public IMatterPartyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MatterPartyService(this._client.WithOptions(modifier));
    }

    public MatterPartyService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MatterPartyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Create(
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Create(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Create(
        string id,
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Create(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task List(
        MatterPartyListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.List(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task List(
        string id,
        MatterPartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.List(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MatterPartyServiceWithRawResponse : IMatterPartyServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMatterPartyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MatterPartyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MatterPartyServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MatterPartyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Create(
        string id,
        MatterPartyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        MatterPartyListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CasedevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<MatterPartyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> List(
        string id,
        MatterPartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}
