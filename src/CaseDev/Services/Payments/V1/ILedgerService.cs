using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Ledger;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILedgerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILedgerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List ledger entries with optional filters by account, transaction, or date range
    /// </summary>
    Task Get(LedgerGetParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query ledger transactions with optional filters
    /// </summary>
    Task ListTransactions(
        LedgerListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILedgerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILedgerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILedgerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/ledger`, but is otherwise the
    /// same as <see cref="ILedgerService.Get(LedgerGetParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Get(
        LedgerGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/ledger/transactions`, but is otherwise the
    /// same as <see cref="ILedgerService.ListTransactions(LedgerListTransactionsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListTransactions(
        LedgerListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
