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
    /// Retrieve metadata for a published workflow by ID. Returns workflow configuration
    /// including input/output schemas, but excludes the prompt template for security.
    /// </summary>
    Task Retrieve(V1RetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(V1RetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a paginated list of available workflows with optional filtering
    /// by category, subcategory, type, and publication status. Workflows are pre-built
    /// document processing pipelines optimized for legal use cases.
    /// </summary>
    Task List(V1ListParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute a pre-built workflow with custom input data. Workflows automate common
    /// legal document processing tasks like contract analysis, due diligence reviews,
    /// and document classification.
    ///
    /// <para>**Available Workflows:** - Contract analysis and risk assessment - Document
    /// classification and tagging - Legal research and case summarization - Due diligence
    /// document review - Compliance checking and reporting</para>
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
    /// Retrieves the status and details of a workflow execution. This endpoint is
    /// designed for future asynchronous execution support and currently returns a
    /// 501 Not Implemented status since all executions are synchronous.
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

    /// <summary>
    /// Perform semantic search across available workflows to find the most relevant
    /// pre-built document processing pipelines for your legal use case.
    /// </summary>
    Task Search(V1SearchParams parameters, CancellationToken cancellationToken = default);
}
