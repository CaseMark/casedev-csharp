using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Webhooks.V1.Deliveries;

namespace Casedev.Services.Webhooks.V1;

/// <summary>
/// Webhook endpoint management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDeliveryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDeliveryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeliveryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get webhook delivery
    /// </summary>
    Task Retrieve(DeliveryRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(DeliveryRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        DeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns delivery attempts for the organization, newest first. Filter by
    /// endpoint_id or status to narrow results.
    /// </summary>
    Task List(DeliveryListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Re-sends the original event to its endpoint. The payload is reconstructed from
    /// the delivery record (same eventId, eventType, and occurred_at). Replay
    /// deliveries include a Case.dev replay marker header so receivers can distinguish
    /// replays from first-time deliveries. Uses the endpoint's current signing secret —
    /// not the one in force at the original delivery time.
    /// </summary>
    Task Replay(DeliveryReplayParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Replay(DeliveryReplayParams, CancellationToken)"/>
    Task Replay(
        string id,
        DeliveryReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDeliveryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDeliveryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeliveryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/v1/deliveries/{id}</c>, but is otherwise the
    /// same as <see cref="IDeliveryService.Retrieve(DeliveryRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        DeliveryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeliveryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        DeliveryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/v1/deliveries</c>, but is otherwise the
    /// same as <see cref="IDeliveryService.List(DeliveryListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        DeliveryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks/v1/deliveries/{id}/replay</c>, but is otherwise the
    /// same as <see cref="IDeliveryService.Replay(DeliveryReplayParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Replay(
        DeliveryReplayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replay(DeliveryReplayParams, CancellationToken)"/>
    Task<HttpResponse> Replay(
        string id,
        DeliveryReplayParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
