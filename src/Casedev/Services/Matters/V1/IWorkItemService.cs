using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.WorkItems;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWorkItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an active work item on a matter.
    /// </summary>
    Task Create(WorkItemCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(WorkItemCreateParams, CancellationToken)"/>
    Task Create(
        string id,
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single work item for a matter.
    /// </summary>
    Task Retrieve(WorkItemRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(WorkItemRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string workItemID,
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a matter work item.
    /// </summary>
    Task Update(WorkItemUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(WorkItemUpdateParams, CancellationToken)"/>
    Task Update(
        string workItemID,
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List active work items for a matter.
    /// </summary>
    Task List(WorkItemListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(WorkItemListParams, CancellationToken)"/>
    Task List(
        string id,
        WorkItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve, revise, block, or reassign a work item. Used by humans or agents to
    /// move work items through their lifecycle.
    /// </summary>
    Task Decide(WorkItemDecideParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Decide(WorkItemDecideParams, CancellationToken)"/>
    Task Decide(
        string workItemID,
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List execution attempts for a work item, including agent and run linkage.
    /// </summary>
    Task ListExecutions(
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListExecutions(WorkItemListExecutionsParams, CancellationToken)"/>
    Task ListExecutions(
        string workItemID,
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/work-items</c>, but is otherwise the
    /// same as <see cref="IWorkItemService.Create(WorkItemCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(WorkItemCreateParams, CancellationToken)"/>
    Task<HttpResponse> Create(
        string id,
        WorkItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/work-items/{workItemId}</c>, but is otherwise the
    /// same as <see cref="IWorkItemService.Retrieve(WorkItemRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Retrieve(
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkItemRetrieveParams, CancellationToken)"/>
    Task<HttpResponse> Retrieve(
        string workItemID,
        WorkItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /matters/v1/{id}/work-items/{workItemId}</c>, but is otherwise the
    /// same as <see cref="IWorkItemService.Update(WorkItemUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkItemUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string workItemID,
        WorkItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/work-items</c>, but is otherwise the
    /// same as <see cref="IWorkItemService.List(WorkItemListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        WorkItemListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkItemListParams, CancellationToken)"/>
    Task<HttpResponse> List(
        string id,
        WorkItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/work-items/{workItemId}/decision</c>, but is otherwise the
    /// same as <see cref="IWorkItemService.Decide(WorkItemDecideParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Decide(
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Decide(WorkItemDecideParams, CancellationToken)"/>
    Task<HttpResponse> Decide(
        string workItemID,
        WorkItemDecideParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/work-items/{workItemId}/executions</c>, but is otherwise the
    /// same as <see cref="IWorkItemService.ListExecutions(WorkItemListExecutionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ListExecutions(
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListExecutions(WorkItemListExecutionsParams, CancellationToken)"/>
    Task<HttpResponse> ListExecutions(
        string workItemID,
        WorkItemListExecutionsParams parameters,
        CancellationToken cancellationToken = default
    );
}
