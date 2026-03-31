using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Matters.V1.Log;

namespace Casedev.Services.Matters.V1;

/// <summary>
/// Matter-native legal workspaces and orchestration primitives
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILogService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILogServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILogService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Append a manual operational note or event to a matter log.
    /// </summary>
    Task Create(LogCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(LogCreateParams, CancellationToken)"/>
    Task Create(
        string id,
        LogCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the operational history for a matter.
    /// </summary>
    Task List(LogListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(LogListParams, CancellationToken)"/>
    Task List(
        string id,
        LogListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bulk export matter log entries for audits, visibility, and eval pipelines.
    /// Supports json, csv, tsv, and jsonl. Limited to 10,000 entries per request.
    /// </summary>
    Task<LogExportResponse> Export(
        LogExportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Export(LogExportParams, CancellationToken)"/>
    Task<LogExportResponse> Export(
        string id,
        LogExportParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILogService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILogServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILogServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/log</c>, but is otherwise the
    /// same as <see cref="ILogService.Create(LogCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Create(
        LogCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LogCreateParams, CancellationToken)"/>
    Task<HttpResponse> Create(
        string id,
        LogCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /matters/v1/{id}/log</c>, but is otherwise the
    /// same as <see cref="ILogService.List(LogListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> List(
        LogListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(LogListParams, CancellationToken)"/>
    Task<HttpResponse> List(
        string id,
        LogListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /matters/v1/{id}/log/export</c>, but is otherwise the
    /// same as <see cref="ILogService.Export(LogExportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LogExportResponse>> Export(
        LogExportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Export(LogExportParams, CancellationToken)"/>
    Task<HttpResponse<LogExportResponse>> Export(
        string id,
        LogExportParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
