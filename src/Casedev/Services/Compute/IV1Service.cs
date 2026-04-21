using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Compute.V1;
using Casedev.Services.Compute.V1;

namespace Casedev.Services.Compute;

/// <summary>
/// Serverless GPU and CPU infrastructure
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

    IEnvironmentService Environments { get; }

    ISecretService Secrets { get; }

    /// <summary>
    /// Returns detailed compute usage statistics and billing information for your
    /// organization. Includes GPU and CPU hours, total runs, costs, and breakdowns by
    /// environment. Use optional query parameters to filter by specific year and month.
    /// </summary>
    Task<V1GetUsageResponse> GetUsage(
        V1GetUsageParams? parameters = null,
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

    IEnvironmentServiceWithRawResponse Environments { get; }

    ISecretServiceWithRawResponse Secrets { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /compute/v1/usage</c>, but is otherwise the
    /// same as <see cref="IV1Service.GetUsage(V1GetUsageParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1GetUsageResponse>> GetUsage(
        V1GetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
