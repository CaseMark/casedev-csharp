using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1;
using CaseDev.Services.Compute.V1;

namespace CaseDev.Services.Compute;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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

    IFunctionService Functions { get; }

    IInvokeService Invoke { get; }

    IRunService Runs { get; }

    ISecretService Secrets { get; }

    /// <summary>
    /// Returns current pricing for GPU instances. Prices are fetched in real-time
    /// and include a 20% platform fee. For detailed instance types and availability,
    /// use GET /compute/v1/instance-types.
    /// </summary>
    Task GetPricing(
        V1GetPricingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns detailed compute usage statistics and billing information for your
    /// organization. Includes GPU and CPU hours, total runs, costs, and breakdowns
    /// by environment. Use optional query parameters to filter by specific year
    /// and month.
    /// </summary>
    Task GetUsage(
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

    IFunctionServiceWithRawResponse Functions { get; }

    IInvokeServiceWithRawResponse Invoke { get; }

    IRunServiceWithRawResponse Runs { get; }

    ISecretServiceWithRawResponse Secrets { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/pricing`, but is otherwise the
    /// same as <see cref="IV1Service.GetPricing(V1GetPricingParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetPricing(
        V1GetPricingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /compute/v1/usage`, but is otherwise the
    /// same as <see cref="IV1Service.GetUsage(V1GetUsageParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetUsage(
        V1GetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
