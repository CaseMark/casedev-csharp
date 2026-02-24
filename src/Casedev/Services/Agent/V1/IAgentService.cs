using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V1.Agents;

namespace Casedev.Services.Agent.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new agent definition with a scoped API key. The agent can then
    /// be used to create and execute runs.
    /// </summary>
    Task<AgentCreateResponse> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single agent definition by ID.
    /// </summary>
    Task<AgentRetrieveResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<AgentRetrieveResponse> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an agent definition. Only provided fields are changed.
    /// </summary>
    Task<AgentUpdateResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<AgentUpdateResponse> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all active agents for the authenticated organization.
    /// </summary>
    Task<AgentListResponse> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Soft-deletes an agent and revokes its scoped API key.
    /// </summary>
    Task<AgentDeleteResponse> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task<AgentDeleteResponse> Delete(
        string id,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /agent/v1/agents`, but is otherwise the
    /// same as <see cref="IAgentService.Create(AgentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentCreateResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /agent/v1/agents/{id}`, but is otherwise the
    /// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentRetrieveResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AgentRetrieveResponse>> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /agent/v1/agents/{id}`, but is otherwise the
    /// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentUpdateResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AgentUpdateResponse>> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /agent/v1/agents`, but is otherwise the
    /// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentListResponse>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /agent/v1/agents/{id}`, but is otherwise the
    /// same as <see cref="IAgentService.Delete(AgentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDeleteResponse>> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AgentDeleteResponse>> Delete(
        string id,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
