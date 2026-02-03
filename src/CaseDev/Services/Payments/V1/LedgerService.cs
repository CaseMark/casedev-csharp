using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Ledger;

namespace CaseDev.Services.Payments.V1;

/// <inheritdoc/>
public sealed class LedgerService : ILedgerService
{
    readonly Lazy<ILedgerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILedgerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICasedevClient _client;

    /// <inheritdoc/>
    public ILedgerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerService(this._client.WithOptions(modifier));
    }

    public LedgerService(ICasedevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LedgerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Get(
        LedgerGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Get(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task ListTransactions(
        LedgerListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ListTransactions(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LedgerServiceWithRawResponse : ILedgerServiceWithRawResponse
{
    readonly ICasedevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILedgerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LedgerServiceWithRawResponse(ICasedevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Get(
        LedgerGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LedgerGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ListTransactions(
        LedgerListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LedgerListTransactionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
