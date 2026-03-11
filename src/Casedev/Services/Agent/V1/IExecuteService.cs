using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V1.Execute;

namespace Casedev.Services.Agent.V1;

/// <summary>
/// Create, manage, and execute AI agents with tool access, sandbox environments,
/// and async run workflows
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExecuteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExecuteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExecuteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates an ephemeral agent and immediately executes a run. Returns the run
    /// ID for polling status and results. This is the fastest way to run an agent
    /// without managing agent lifecycle.
    ///
    /// <para>**Ephemeral agent lifecycle:** The agent created by this endpoint is
    /// automatically soft-deleted and its scoped API key revoked when the run completes
    /// (whether it succeeds, fails, or times out). Ephemeral agents do not appear
    /// in GET /agent/v1/agents listings. The returned agentId is valid only for the
    /// duration of the run — do not store it for reuse. For persistent, reusable
    /// agents, use POST /agent/v1/agents instead.</para>
    /// </summary>
    Task<ExecuteCreateResponse> Create(
        ExecuteCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExecuteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExecuteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExecuteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /agent/v1/execute`, but is otherwise the
    /// same as <see cref="IExecuteService.Create(ExecuteCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExecuteCreateResponse>> Create(
        ExecuteCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
