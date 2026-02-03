using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Payouts;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPayoutService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPayoutServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPayoutService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a payout to send money to an external bank account
    /// </summary>
    Task Create(PayoutCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get payout details by ID
    /// </summary>
    Task Retrieve(PayoutRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(PayoutRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        PayoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List payouts with optional filters
    /// </summary>
    Task List(PayoutListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancel a pending payout before it is processed
    /// </summary>
    Task Cancel(PayoutCancelParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Cancel(PayoutCancelParams, CancellationToken)"/>
    Task Cancel(
        string id,
        PayoutCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPayoutService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPayoutServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPayoutServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/payouts`, but is otherwise the
    /// same as <see cref="IPayoutService.Create(PayoutCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        PayoutCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/payouts/{id}`, but is otherwise the
    /// same as <see cref="IPayoutService.Retrieve(PayoutRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        PayoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PayoutRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        PayoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/payouts`, but is otherwise the
    /// same as <see cref="IPayoutService.List(PayoutListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        PayoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/payouts/{id}/cancel`, but is otherwise the
    /// same as <see cref="IPayoutService.Cancel(PayoutCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Cancel(
        PayoutCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(PayoutCancelParams, CancellationToken)"/>
    Task<HttpResponse> Cancel(
        string id,
        PayoutCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
