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
    /// Deploy code to Case.dev's serverless compute infrastructure powered by Modal.
    /// Supports Python, Dockerfile, and container image runtimes with GPU acceleration
    /// for AI/ML workloads. Code is deployed as tasks (batch jobs) or services (web
    /// endpoints) with automatic scaling.
    /// </summary>
    Task<V1DeployResponse> Deploy(
        V1DeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns current pricing for GPU and CPU compute resources. This public endpoint
    /// provides detailed pricing information for all available compute types, including
    /// GPU instances and CPU cores, with billing model details.
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
