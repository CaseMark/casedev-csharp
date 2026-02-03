using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Accounts;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new payment account (trust, operating, escrow, client sub-account, etc.)
    /// </summary>
    Task<AccountCreateResponse> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a payment account by ID
    /// </summary>
    Task Retrieve(AccountRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a payment account
    /// </summary>
    Task Update(AccountUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        AccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all payment accounts for the organization
    /// </summary>
    Task<JsonElement> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the current balance for an account, computed from the ledger
    /// </summary>
    Task<AccountGetBalanceResponse> GetBalance(
        AccountGetBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetBalance(AccountGetBalanceParams, CancellationToken)"/>
    Task<AccountGetBalanceResponse> GetBalance(
        string id,
        AccountGetBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get ledger entries for a specific account
    /// </summary>
    Task<AccountGetLedgerResponse> GetLedger(
        AccountGetLedgerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetLedger(AccountGetLedgerParams, CancellationToken)"/>
    Task<AccountGetLedgerResponse> GetLedger(
        string id,
        AccountGetLedgerParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/accounts`, but is otherwise the
    /// same as <see cref="IAccountService.Create(AccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountCreateResponse>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/accounts/{id}`, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /payments/v1/accounts/{id}`, but is otherwise the
    /// same as <see cref="IAccountService.Update(AccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        AccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/accounts`, but is otherwise the
    /// same as <see cref="IAccountService.List(AccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/accounts/{id}/balance`, but is otherwise the
    /// same as <see cref="IAccountService.GetBalance(AccountGetBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountGetBalanceResponse>> GetBalance(
        AccountGetBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetBalance(AccountGetBalanceParams, CancellationToken)"/>
    Task<HttpResponse<AccountGetBalanceResponse>> GetBalance(
        string id,
        AccountGetBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/accounts/{id}/ledger`, but is otherwise the
    /// same as <see cref="IAccountService.GetLedger(AccountGetLedgerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountGetLedgerResponse>> GetLedger(
        AccountGetLedgerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetLedger(AccountGetLedgerParams, CancellationToken)"/>
    Task<HttpResponse<AccountGetLedgerResponse>> GetLedger(
        string id,
        AccountGetLedgerParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
