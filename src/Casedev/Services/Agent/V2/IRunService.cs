using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V2.Run;

namespace Casedev.Services.Agent.V2;

/// <summary>
/// Create, manage, and execute AI agents with tool access, sandbox environments,
/// and async run workflows
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Creates a v2 run in queued state. Call POST /agent/v2/run/:id/exec to start
    /// execution on the Daytona runtime.
    /// </summary>
    Task<RunCreateResponse> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Streams real-time v2 run events over SSE with replay support.
    /// </summary>
    IAsyncEnumerable<string> EventsStreaming(
        RunEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="EventsStreaming(RunEventsParams, CancellationToken)"/>
    IAsyncEnumerable<string> EventsStreaming(
        string id,
        RunEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts execution of a queued v2 run. The agent runs in a durable workflow on a
    /// Daytona runtime.
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
    /// Full audit trail for a v2 run, with provider-neutral runtime metadata.
    /// </summary>
    Task<JsonElement> GetDetails(
        RunGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDetails(RunGetDetailsParams, CancellationToken)"/>
    Task<JsonElement> GetDetails(
        string id,
        RunGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lightweight status poll for a v2 run including neutral runtime metadata.
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
    /// Returns a raw HTTP response for <c>post /agent/v2/run</c>, but is otherwise the
    /// same as <see cref="IRunService.Create(RunCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RunCreateResponse>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/v2/run/{id}/events</c>, but is otherwise the
    /// same as <see cref="IRunService.EventsStreaming(RunEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<string>> EventsStreaming(
        RunEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="EventsStreaming(RunEventsParams, CancellationToken)"/>
    Task<StreamingHttpResponse<string>> EventsStreaming(
        string id,
        RunEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /agent/v2/run/{id}/exec</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /agent/v2/run/{id}/details</c>, but is otherwise the
    /// same as <see cref="IRunService.GetDetails(RunGetDetailsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> GetDetails(
        RunGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDetails(RunGetDetailsParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> GetDetails(
        string id,
        RunGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/v2/run/{id}/status</c>, but is otherwise the
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
}
