using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Usage.V1.Subscriptions;

namespace Casedev.Services.Usage.V1;

/// <summary>
/// Usage reporting and webhook subscriptions
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
    /// Creates a webhook subscription for usage, balance, and billing events.
    /// </summary>
    Task Create(SubscriptionCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates callback URL, event filters, active state, or signing secret.
    /// </summary>
    Task Update(SubscriptionUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists webhook subscriptions configured for usage and billing events.
    /// </summary>
    Task List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivates a usage webhook subscription.
    /// </summary>
    Task Delete(SubscriptionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delivers a test event to a single usage webhook subscription using the same
    /// payload shape and signing behavior as production delivery.
    /// </summary>
    Task Test(SubscriptionTestParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Test(SubscriptionTestParams, CancellationToken)"/>
    Task Test(
        string subscriptionID,
        SubscriptionTestParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /usage/v1/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Create(SubscriptionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        SubscriptionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /usage/v1/subscriptions/{subscriptionId}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Update(SubscriptionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string subscriptionID,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /usage/v1/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /usage/v1/subscriptions/{subscriptionId}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Delete(SubscriptionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        SubscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SubscriptionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string subscriptionID,
        SubscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /usage/v1/subscriptions/{subscriptionId}/test</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Test(SubscriptionTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Test(
        SubscriptionTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(SubscriptionTestParams, CancellationToken)"/>
    Task<HttpResponse> Test(
        string subscriptionID,
        SubscriptionTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
