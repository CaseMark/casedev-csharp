using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Compute.V1.Functions;

namespace CaseDev.Services.Compute.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFunctionService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves all serverless functions deployed in a specified compute environment.
    /// Functions can be used for custom document processing, AI model inference,
    /// or other computational tasks in legal workflows.
    /// </summary>
    Task List(FunctionListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve execution logs from a deployed serverless function. Logs include
    /// function output, errors, and runtime information. Useful for debugging and
    /// monitoring function performance in production.
    /// </summary>
    Task GetLogs(FunctionGetLogsParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetLogs(FunctionGetLogsParams, CancellationToken)"/>
    Task GetLogs(
        string id,
        FunctionGetLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
