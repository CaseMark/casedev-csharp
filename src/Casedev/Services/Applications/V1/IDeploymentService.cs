using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Applications.V1.Deployments;

namespace Casedev.Services.Applications.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDeploymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDeploymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeploymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Trigger a new deployment for a project
    /// </summary>
    Task Create(DeploymentCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get details of a specific deployment including build logs
    /// </summary>
    Task Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeploymentRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List deployments for a project
    /// </summary>
    Task List(DeploymentListParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancel a running deployment
    /// </summary>
    Task Cancel(DeploymentCancelParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Cancel(DeploymentCancelParams, CancellationToken)"/>
    Task Cancel(
        string id,
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a deployment from raw file contents (for Thurgood sandbox deployments)
    /// </summary>
    Task CreateFromFiles(
        DeploymentCreateFromFilesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get build logs for a specific deployment
    /// </summary>
    Task GetLogs(DeploymentGetLogsParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetLogs(DeploymentGetLogsParams, CancellationToken)"/>
    Task GetLogs(
        string id,
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the current status of a deployment
    /// </summary>
    Task GetStatus(
        DeploymentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(DeploymentGetStatusParams, CancellationToken)"/>
    Task GetStatus(
        string id,
        DeploymentGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stream real-time deployment progress events via Server-Sent Events
    /// </summary>
    Task Stream(DeploymentStreamParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Stream(DeploymentStreamParams, CancellationToken)"/>
    Task Stream(
        string id,
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDeploymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDeploymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeploymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/deployments`, but is otherwise the
    /// same as <see cref="IDeploymentService.Create(DeploymentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/deployments/{id}`, but is otherwise the
    /// same as <see cref="IDeploymentService.Retrieve(DeploymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeploymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string id,
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/deployments`, but is otherwise the
    /// same as <see cref="IDeploymentService.List(DeploymentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        DeploymentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/deployments/{id}/cancel`, but is otherwise the
    /// same as <see cref="IDeploymentService.Cancel(DeploymentCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Cancel(
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(DeploymentCancelParams, CancellationToken)"/>
    Task<HttpResponse> Cancel(
        string id,
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /applications/v1/deployments/from-files`, but is otherwise the
    /// same as <see cref="IDeploymentService.CreateFromFiles(DeploymentCreateFromFilesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateFromFiles(
        DeploymentCreateFromFilesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/deployments/{id}/logs`, but is otherwise the
    /// same as <see cref="IDeploymentService.GetLogs(DeploymentGetLogsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetLogs(
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetLogs(DeploymentGetLogsParams, CancellationToken)"/>
    Task<HttpResponse> GetLogs(
        string id,
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/deployments/{id}/status`, but is otherwise the
    /// same as <see cref="IDeploymentService.GetStatus(DeploymentGetStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> GetStatus(
        DeploymentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(DeploymentGetStatusParams, CancellationToken)"/>
    Task<HttpResponse> GetStatus(
        string id,
        DeploymentGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /applications/v1/deployments/{id}/stream`, but is otherwise the
    /// same as <see cref="IDeploymentService.Stream(DeploymentStreamParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Stream(
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(DeploymentStreamParams, CancellationToken)"/>
    Task<HttpResponse> Stream(
        string id,
        DeploymentStreamParams parameters,
        CancellationToken cancellationToken = default
    );
}
