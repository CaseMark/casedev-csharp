using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Workflows.V1;

namespace CaseDev.Services.Workflows;

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

    /// <summary>
    /// Create a new visual workflow with nodes, edges, and trigger configuration.
    /// </summary>
    Task<V1CreateResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific workflow by ID with full configuration.
    /// </summary>
    Task<V1RetrieveResponse> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task<V1RetrieveResponse> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing workflow's configuration.
    /// </summary>
    Task<V1UpdateResponse> Update(
        V1UpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(V1UpdateParams, CancellationToken)"/>
    Task<V1UpdateResponse> Update(
        string id,
        V1UpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all workflows for the authenticated organization.
    /// </summary>
    Task<V1ListResponse> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a workflow and all associated data.
    /// </summary>
    Task<V1DeleteResponse> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<V1DeleteResponse> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deploy a workflow to Modal compute. Returns a webhook URL and secret for triggering
    /// the workflow.
    /// </summary>
    Task<V1DeployResponse> Deploy(
        V1DeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deploy(V1DeployParams, CancellationToken)"/>
    Task<V1DeployResponse> Deploy(
        string id,
        V1DeployParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute a workflow for testing. This runs the workflow synchronously without deployment.
    /// </summary>
    Task<V1ExecuteResponse> Execute(
        V1ExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Execute(V1ExecuteParams, CancellationToken)"/>
    Task<V1ExecuteResponse> Execute(
        string id,
        V1ExecuteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all executions for a specific workflow.
    /// </summary>
    Task<V1ListExecutionsResponse> ListExecutions(
        V1ListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListExecutions(V1ListExecutionsParams, CancellationToken)"/>
    Task<V1ListExecutionsResponse> ListExecutions(
        string id,
        V1ListExecutionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get detailed information about a workflow execution.
    /// </summary>
    Task<V1RetrieveExecutionResponse> RetrieveExecution(
        V1RetrieveExecutionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveExecution(V1RetrieveExecutionParams, CancellationToken)"/>
    Task<V1RetrieveExecutionResponse> RetrieveExecution(
        string id,
        V1RetrieveExecutionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop a deployed workflow and release its webhook URL.
    /// </summary>
    Task<V1UndeployResponse> Undeploy(
        V1UndeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Undeploy(V1UndeployParams, CancellationToken)"/>
    Task<V1UndeployResponse> Undeploy(
        string id,
        V1UndeployParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
