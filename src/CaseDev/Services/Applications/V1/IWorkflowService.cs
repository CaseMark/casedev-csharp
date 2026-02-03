using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Applications.V1.Workflows;

namespace CaseDev.Services.Applications.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWorkflowService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkflowServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkflowService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get current deployment workflow status and accumulated events
    /// </summary>
    Task GetStatus(
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(WorkflowGetStatusParams, CancellationToken)"/>
    Task GetStatus(
        string id,
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkflowService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkflowServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkflowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/workflows/{id}/status`, but is otherwise the
    /// same as <see cref="IWorkflowService.GetStatus(WorkflowGetStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetStatus(
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(WorkflowGetStatusParams, CancellationToken)"/>
    Task<HttpResponse> GetStatus(
        string id,
        WorkflowGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );
}
