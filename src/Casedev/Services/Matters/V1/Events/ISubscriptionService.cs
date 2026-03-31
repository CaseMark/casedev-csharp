using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.Events.Subscriptions;

namespace Casedev.Services.Matters.V1.Events;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a webhook subscription for matter and work-item events.
    /// </summary>
    Task Create(SubscriptionCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(SubscriptionCreateParams, CancellationToken)"/>
    Task Create(
        string id,
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists webhook subscriptions configured for a matter.
    /// </summary>
    Task List(SubscriptionListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task List(
        string id,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a matter webhook subscription.
    /// </summary>
    Task Delete(SubscriptionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task Delete(
        string subscriptionID,
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/events/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Create(SubscriptionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(SubscriptionCreateParams, CancellationToken)"/>
    Task<HttpResponse> Create(
        string id,
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/events/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task<HttpResponse> List(
        string id,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /matters/v1/{id}/events/subscriptions/{subscriptionId}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Delete(SubscriptionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string subscriptionID,
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
