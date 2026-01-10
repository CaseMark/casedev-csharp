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
    /// Deploy a workflow to AWS Step Functions. Returns a webhook URL and secret
    /// for triggering the workflow.
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
    /// Execute a deployed workflow. Supports three modes: - **Fire-and-forget** (default):
    /// Returns immediately with executionId. Poll /executions/{id} for status. -
    /// **Callback**: Returns immediately, POSTs result to callbackUrl when workflow
    /// completes. - **Sync wait**: Blocks until workflow completes (max 5 minutes).
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
    /// Get detailed information about a workflow execution, including live Step
    /// Functions status.
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
    /// Stop a deployed workflow and delete its Step Functions state machine.
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

    /// <summary>
    /// Returns a raw HTTP response for `post /workflows/v1`, but is otherwise the
    /// same as <see cref="IV1Service.Create(V1CreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1CreateResponse>> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /workflows/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Retrieve(V1RetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1RetrieveResponse>> Retrieve(
        V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task<HttpResponse<V1RetrieveResponse>> Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /workflows/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Update(V1UpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1UpdateResponse>> Update(
        V1UpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(V1UpdateParams, CancellationToken)"/>
    Task<HttpResponse<V1UpdateResponse>> Update(
        string id,
        V1UpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /workflows/v1`, but is otherwise the
    /// same as <see cref="IV1Service.List(V1ListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListResponse>> List(
        V1ListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /workflows/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Delete(V1DeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DeleteResponse>> Delete(
        V1DeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task<HttpResponse<V1DeleteResponse>> Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /workflows/v1/{id}/deploy`, but is otherwise the
    /// same as <see cref="IV1Service.Deploy(V1DeployParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1DeployResponse>> Deploy(
        V1DeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deploy(V1DeployParams, CancellationToken)"/>
    Task<HttpResponse<V1DeployResponse>> Deploy(
        string id,
        V1DeployParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /workflows/v1/{id}/execute`, but is otherwise the
    /// same as <see cref="IV1Service.Execute(V1ExecuteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ExecuteResponse>> Execute(
        V1ExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Execute(V1ExecuteParams, CancellationToken)"/>
    Task<HttpResponse<V1ExecuteResponse>> Execute(
        string id,
        V1ExecuteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /workflows/v1/{id}/executions`, but is otherwise the
    /// same as <see cref="IV1Service.ListExecutions(V1ListExecutionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1ListExecutionsResponse>> ListExecutions(
        V1ListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListExecutions(V1ListExecutionsParams, CancellationToken)"/>
    Task<HttpResponse<V1ListExecutionsResponse>> ListExecutions(
        string id,
        V1ListExecutionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /workflows/v1/executions/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.RetrieveExecution(V1RetrieveExecutionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1RetrieveExecutionResponse>> RetrieveExecution(
        V1RetrieveExecutionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveExecution(V1RetrieveExecutionParams, CancellationToken)"/>
    Task<HttpResponse<V1RetrieveExecutionResponse>> RetrieveExecution(
        string id,
        V1RetrieveExecutionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /workflows/v1/{id}/deploy`, but is otherwise the
    /// same as <see cref="IV1Service.Undeploy(V1UndeployParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1UndeployResponse>> Undeploy(
        V1UndeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Undeploy(V1UndeployParams, CancellationToken)"/>
    Task<HttpResponse<V1UndeployResponse>> Undeploy(
        string id,
        V1UndeployParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
