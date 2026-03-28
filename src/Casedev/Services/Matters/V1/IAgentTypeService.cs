using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.AgentTypes;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAgentTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a reusable agent role for legal matter orchestration.
    /// </summary>
    Task Create(AgentTypeCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// List reusable agent roles for the authenticated organization.
    /// </summary>
    Task List(
        AgentTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/agent-types</c>, but is otherwise the
    /// same as <see cref="IAgentTypeService.Create(AgentTypeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        AgentTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/agent-types</c>, but is otherwise the
    /// same as <see cref="IAgentTypeService.List(AgentTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        AgentTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
