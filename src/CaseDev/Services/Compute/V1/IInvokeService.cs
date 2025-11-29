using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Invoke;

namespace CaseDev.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvokeService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Execute a deployed compute function with custom input data. Supports both
    /// synchronous and asynchronous execution modes. Functions can be invoked by
    /// ID or name and can process various types of input data for legal document
    /// analysis, data processing, or other computational tasks.
    /// </summary>
    Task<InvokeRunResponse> Run(
        InvokeRunParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Run(InvokeRunParams, CancellationToken)"/>
    Task<InvokeRunResponse> Run(
        string functionID,
        InvokeRunParams parameters,
        CancellationToken cancellationToken = default
    );
}
