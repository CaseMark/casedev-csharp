using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Applications.V1.Deployments;

namespace Casedev.Services.Applications.V1;

/// <summary>
/// Web application deployment management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Creates a deployment for an existing project by fetching repository files from
    /// GitHub and uploading them to the hosting provider. Use ref to deploy a branch,
    /// tag, or commit other than the project default branch.
    /// </summary>
    Task Create(DeploymentCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns deployment details for one project in the authenticated organization.
    /// Set includeLogs=true to include recent build output in the response.
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
    /// Lists recent deployments for one project in the authenticated organization. Use
    /// the optional filters to narrow results by target or deployment state.
    /// </summary>
    Task List(DeploymentListParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a running deployment after verifying that the referenced project belongs
    /// to the authenticated organization. Use this when a build is stuck,
    /// misconfigured, or no longer needed.
    /// </summary>
    Task Cancel(DeploymentCancelParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Cancel(DeploymentCancelParams, CancellationToken)"/>
    Task Cancel(
        string id,
        DeploymentCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a deployment from raw file contents for application deployments
    /// </summary>
    Task CreateFromFiles(
        DeploymentCreateFromFilesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns build and runtime log events for a deployment after verifying access to
    /// the owning project. Use this when you need detailed output for a failed or
    /// in-progress build.
    /// </summary>
    Task GetLogs(DeploymentGetLogsParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetLogs(DeploymentGetLogsParams, CancellationToken)"/>
    Task GetLogs(
        string id,
        DeploymentGetLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the current status of a deployment without fetching full build logs. Use
    /// this endpoint for lightweight polling while a deployment is building or waiting
    /// to become ready.
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
    /// Returns a raw HTTP response for <c>post /applications/v1/deployments</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Create(DeploymentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /applications/v1/deployments/{id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /applications/v1/deployments</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.List(DeploymentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        DeploymentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /applications/v1/deployments/{id}/cancel</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>post /applications/v1/deployments/from-files</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.CreateFromFiles(DeploymentCreateFromFilesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateFromFiles(
        DeploymentCreateFromFilesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /applications/v1/deployments/{id}/logs</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /applications/v1/deployments/{id}/status</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /applications/v1/deployments/{id}/stream</c>, but is otherwise the
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
