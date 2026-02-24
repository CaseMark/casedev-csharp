using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V1.Run;

namespace Casedev.Services.Agent.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRunService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRunServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a run in queued state. Call POST /agent/v1/run/:id/exec to start execution.
    /// </summary>
    Task<RunCreateResponse> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a running or queued run. Idempotent — cancelling a finished run returns
    /// its current status.
    /// </summary>
    Task<RunCancelResponse> Cancel(
        RunCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(RunCancelParams, CancellationToken)"/>
    Task<RunCancelResponse> Cancel(
        string id,
        RunCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts execution of a queued run. The agent runs in a durable workflow —
    /// poll /run/:id/status for progress.
    /// </summary>
    Task<RunExecResponse> Exec(
        RunExecParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Exec(RunExecParams, CancellationToken)"/>
    Task<RunExecResponse> Exec(
        string id,
        RunExecParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Full audit trail for a run including output, steps (tool calls, text), and
    /// token usage.
    /// </summary>
    Task<RunGetDetailsResponse> GetDetails(
        RunGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDetails(RunGetDetailsParams, CancellationToken)"/>
    Task<RunGetDetailsResponse> GetDetails(
        string id,
        RunGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lightweight status poll for a run. Use /run/:id/details for the full audit trail.
    /// </summary>
    Task<RunGetStatusResponse> GetStatus(
        RunGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(RunGetStatusParams, CancellationToken)"/>
    Task<RunGetStatusResponse> GetStatus(
        string id,
        RunGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Register a callback URL to receive notifications when the run completes. URL
    /// must use https and must not point to a private network.
    /// </summary>
    Task<RunWatchResponse> Watch(
        RunWatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Watch(RunWatchParams, CancellationToken)"/>
    Task<RunWatchResponse> Watch(
        string id,
        RunWatchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRunService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRunServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /agent/v1/run`, but is otherwise the
    /// same as <see cref="IRunService.Create(RunCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunCreateResponse>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /agent/v1/run/{id}/cancel`, but is otherwise the
    /// same as <see cref="IRunService.Cancel(RunCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunCancelResponse>> Cancel(
        RunCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(RunCancelParams, CancellationToken)"/>
    Task<HttpResponse<RunCancelResponse>> Cancel(
        string id,
        RunCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /agent/v1/run/{id}/exec`, but is otherwise the
    /// same as <see cref="IRunService.Exec(RunExecParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunExecResponse>> Exec(
        RunExecParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Exec(RunExecParams, CancellationToken)"/>
    Task<HttpResponse<RunExecResponse>> Exec(
        string id,
        RunExecParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /agent/v1/run/{id}/details`, but is otherwise the
    /// same as <see cref="IRunService.GetDetails(RunGetDetailsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunGetDetailsResponse>> GetDetails(
        RunGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDetails(RunGetDetailsParams, CancellationToken)"/>
    Task<HttpResponse<RunGetDetailsResponse>> GetDetails(
        string id,
        RunGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /agent/v1/run/{id}/status`, but is otherwise the
    /// same as <see cref="IRunService.GetStatus(RunGetStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunGetStatusResponse>> GetStatus(
        RunGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(RunGetStatusParams, CancellationToken)"/>
    Task<HttpResponse<RunGetStatusResponse>> GetStatus(
        string id,
        RunGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /agent/v1/run/{id}/watch`, but is otherwise the
    /// same as <see cref="IRunService.Watch(RunWatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunWatchResponse>> Watch(
        RunWatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Watch(RunWatchParams, CancellationToken)"/>
    Task<HttpResponse<RunWatchResponse>> Watch(
        string id,
        RunWatchParams parameters,
        CancellationToken cancellationToken = default
    );
}
