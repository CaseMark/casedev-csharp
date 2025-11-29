using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Actions.V1;

namespace CaseDev.Services.Actions;

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
    /// Create a new action definition for multi-step workflow automation. Actions
    /// can be defined using YAML or JSON format and support complex workflows including
    /// document processing, data extraction, and analysis pipelines.
    /// </summary>
    Task<V1CreateResponse> Create(
        V1CreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific action definition by ID. Actions are reusable workflow
    /// components that can perform tasks like document analysis, data extraction,
    /// or API integrations. Only actions belonging to your organization can be accessed.
    /// </summary>
    Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all action definitions for your organization. Actions are reusable
    /// automation components that can perform tasks like document processing, data
    /// extraction, and workflow execution.
    /// </summary>
    Task List(V1ListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Permanently deletes an action definition from your organization. This will
    /// remove all workflow steps and configurations associated with the action.
    /// **Warning:** This operation cannot be undone.
    /// </summary>
    Task Delete(V1DeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(V1DeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        V1DeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute a multi-step action workflow with the provided input data. Actions
    /// can run synchronously (returning results immediately) or asynchronously (with
    /// webhook notifications when complete).
    /// </summary>
    Task<V1ExecuteResponse> Execute(
        V1ExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Execute(V1ExecuteParams, CancellationToken)"/>
    Task<V1ExecuteResponse> Execute(
        string id,
        V1ExecuteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the status and results of a specific action execution. Returns execution
    /// details including current status, results, error messages, and execution metadata.
    /// </summary>
    Task RetrieveExecution(
        V1RetrieveExecutionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveExecution(V1RetrieveExecutionParams, CancellationToken)"/>
    Task RetrieveExecution(
        string id,
        V1RetrieveExecutionParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
