using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Payments.V1.Parties;

namespace CaseDev.Services.Payments.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPartyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPartyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPartyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new payment party (client, vendor, counsel, etc.)
    /// </summary>
    Task Create(PartyCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get party details by ID
    /// </summary>
    Task Retrieve(PartyRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(PartyRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        PartyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update party details
    /// </summary>
    Task Update(PartyUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(PartyUpdateParams, CancellationToken)"/>
    Task Update(
        string id,
        PartyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List payment parties with optional filters
    /// </summary>
    Task List(PartyListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// List saved payment methods for a party (from Stripe)
    /// </summary>
    Task ListPaymentMethods(
        PartyListPaymentMethodsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPaymentMethods(PartyListPaymentMethodsParams, CancellationToken)"/>
    Task ListPaymentMethods(
        string id,
        PartyListPaymentMethodsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPartyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPartyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPartyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /payments/v1/parties`, but is otherwise the
    /// same as <see cref="IPartyService.Create(PartyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        PartyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/parties/{id}`, but is otherwise the
    /// same as <see cref="IPartyService.Retrieve(PartyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        PartyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PartyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        PartyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /payments/v1/parties/{id}`, but is otherwise the
    /// same as <see cref="IPartyService.Update(PartyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        PartyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PartyUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string id,
        PartyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/parties`, but is otherwise the
    /// same as <see cref="IPartyService.List(PartyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        PartyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /payments/v1/parties/{id}/payment-methods`, but is otherwise the
    /// same as <see cref="IPartyService.ListPaymentMethods(PartyListPaymentMethodsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListPaymentMethods(
        PartyListPaymentMethodsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPaymentMethods(PartyListPaymentMethodsParams, CancellationToken)"/>
    Task<HttpResponse> ListPaymentMethods(
        string id,
        PartyListPaymentMethodsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
