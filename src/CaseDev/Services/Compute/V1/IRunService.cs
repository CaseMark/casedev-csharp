using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Runs;

namespace CaseDev.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRunService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve detailed information about a specific compute function run, including
    /// execution status, input/output data, resource usage metrics, and cost information.
    /// </summary>
    Task Retrieve(RunRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        RunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of recent compute runs for your organization. Filter by environment
    /// or function, and limit the number of results returned. Useful for monitoring
    /// serverless function executions and tracking performance metrics.
    /// </summary>
    Task List(RunListParams? parameters = null, CancellationToken cancellationToken = default);
}
