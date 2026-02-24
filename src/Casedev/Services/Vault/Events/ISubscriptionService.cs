using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Vault.Events.Subscriptions;

namespace Casedev.Services.Vault.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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
    /// Creates a webhook subscription for vault lifecycle events. Optional object
    /// filters can limit notifications to specific vault objects.
    /// </summary>
    Task Create(SubscriptionCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(SubscriptionCreateParams, CancellationToken)"/>
    Task Create(
        string id,
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates callback URL, filters, active state, or signing secret for a vault
    /// webhook subscription.
    /// </summary>
    Task Update(SubscriptionUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task Update(
        string subscriptionID,
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists webhook subscriptions configured for a vault.
    /// </summary>
    Task List(SubscriptionListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(SubscriptionListParams, CancellationToken)"/>
    Task List(
        string id,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a vault webhook subscription.
    /// </summary>
    Task Delete(SubscriptionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task Delete(
        string subscriptionID,
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delivers a test event to a single vault webhook subscription. Uses the same
    /// payload shape, signature, and retry behavior as production event delivery.
    /// </summary>
    Task Test(SubscriptionTestParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Test(SubscriptionTestParams, CancellationToken)"/>
    Task Test(
        string subscriptionID,
        SubscriptionTestParams parameters,
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
    /// Returns a raw HTTP response for `post /vault/{id}/events/subscriptions`, but is otherwise the
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
    /// Returns a raw HTTP response for `patch /vault/{id}/events/subscriptions/{subscriptionId}`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Update(SubscriptionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string subscriptionID,
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/events/subscriptions`, but is otherwise the
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
    /// Returns a raw HTTP response for `delete /vault/{id}/events/subscriptions/{subscriptionId}`, but is otherwise the
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

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/events/subscriptions/{subscriptionId}/test`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Test(SubscriptionTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Test(
        SubscriptionTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(SubscriptionTestParams, CancellationToken)"/>
    Task<HttpResponse> Test(
        string subscriptionID,
        SubscriptionTestParams parameters,
        CancellationToken cancellationToken = default
    );
}
