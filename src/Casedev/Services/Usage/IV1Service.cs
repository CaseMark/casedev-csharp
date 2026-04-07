using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Usage.V1;
using Casedev.Services.Usage.V1;

namespace Casedev.Services.Usage;

/// <summary>
/// Usage reporting and webhook subscriptions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISubscriptionService Subscriptions { get; }

    /// <summary>
    /// Returns customer-facing usage metrics and costs for the requested period.
    /// Supports summary totals and daily buckets for timestamped usage sources. Vault
    /// storage is intentionally omitted from totals because it is not yet periodized
    /// for arbitrary windows.
    /// </summary>
    Task Retrieve(
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISubscriptionServiceWithRawResponse Subscriptions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /usage/v1</c>, but is otherwise the
    /// same as <see cref="IV1Service.Retrieve(V1RetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
