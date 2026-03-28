using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Agent.V2.Chat.Files;

namespace Casedev.Services.Agent.V2.Chat;

/// <summary>
/// Create, manage, and execute AI agents with tool access, sandbox environments,
/// and async run workflows
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Lists files created by the agent in the Daytona runtime workspace. Stopped or
    /// archived runtimes are transparently resumed or recovered.
    /// </summary>
    Task<FileListResponse> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FileListParams, CancellationToken)"/>
    Task<FileListResponse> List(
        string id,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads a file from the Daytona runtime workspace by path. Stopped or archived
    /// runtimes are transparently resumed or recovered.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Download(
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(FileDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string filePath,
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/v2/chat/{id}/files</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileListResponse>> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FileListParams, CancellationToken)"/>
    Task<HttpResponse<FileListResponse>> List(
        string id,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /agent/v2/chat/{id}/files/{filePath}</c>, but is otherwise the
    /// same as <see cref="IFileService.Download(FileDownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Download(
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(FileDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string filePath,
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    );
}
