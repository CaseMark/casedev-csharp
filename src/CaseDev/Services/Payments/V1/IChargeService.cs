using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Charges;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChargeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChargeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a charge (payment request) to collect money from a party
    /// </summary>
    Task Create(ChargeCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get charge details by ID
    /// </summary>
    Task Retrieve(ChargeRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(ChargeRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        ChargeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List charges with optional filters
    /// </summary>
    Task List(ChargeListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancel a pending charge before payment is collected
    /// </summary>
    Task Cancel(ChargeCancelParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Cancel(ChargeCancelParams, CancellationToken)"/>
    Task Cancel(
        string id,
        ChargeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refund a succeeded charge (full or partial)
    /// </summary>
    Task Refund(ChargeRefundParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Refund(ChargeRefundParams, CancellationToken)"/>
    Task Refund(
        string id,
        ChargeRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChargeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChargeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChargeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/charges`, but is otherwise the
    /// same as <see cref="IChargeService.Create(ChargeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        ChargeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/charges/{id}`, but is otherwise the
    /// same as <see cref="IChargeService.Retrieve(ChargeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        ChargeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChargeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        ChargeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/charges`, but is otherwise the
    /// same as <see cref="IChargeService.List(ChargeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        ChargeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/charges/{id}/cancel`, but is otherwise the
    /// same as <see cref="IChargeService.Cancel(ChargeCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Cancel(
        ChargeCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ChargeCancelParams, CancellationToken)"/>
    Task<HttpResponse> Cancel(
        string id,
        ChargeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/charges/{id}/refund`, but is otherwise the
    /// same as <see cref="IChargeService.Refund(ChargeRefundParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Refund(
        ChargeRefundParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Refund(ChargeRefundParams, CancellationToken)"/>
    Task<HttpResponse> Refund(
        string id,
        ChargeRefundParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
