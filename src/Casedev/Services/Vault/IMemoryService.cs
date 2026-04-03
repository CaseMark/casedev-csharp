using System;
using System.Threading;
using System.Threading.Tasks;
using Casedev.Core;
using Casedev.Models.Vault.Memory;

namespace Casedev.Services.Vault;

/// <summary>
/// Secure document storage with semantic search and GraphRAG
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMemoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Append a new file-backed memory entry to a vault.
    /// </summary>
    Task<MemoryCreateResponse> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MemoryCreateParams, CancellationToken)"/>
    Task<MemoryCreateResponse> Create(
        string id,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rewrite a file-backed vault memory entry with updated content, source, or tags.
    /// </summary>
    Task Update(MemoryUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(MemoryUpdateParams, CancellationToken)"/>
    Task Update(
        string entryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve file-backed memory entries stored in a vault.
    /// </summary>
    Task<MemoryListResponse> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemoryListParams, CancellationToken)"/>
    Task<MemoryListResponse> List(
        string id,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a file-backed memory entry from a vault.
    /// </summary>
    Task Delete(MemoryDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(MemoryDeleteParams, CancellationToken)"/>
    Task Delete(
        string entryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search file-backed vault memory using simple full-text matching over content and
    /// tags.
    /// </summary>
    Task<MemorySearchResponse> Search(
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Search(MemorySearchParams, CancellationToken)"/>
    Task<MemorySearchResponse> Search(
        string id,
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMemoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /vault/{id}/memory</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Create(MemoryCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemoryCreateResponse>> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MemoryCreateParams, CancellationToken)"/>
    Task<HttpResponse<MemoryCreateResponse>> Create(
        string id,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /vault/{id}/memory/{entryId}</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Update(MemoryUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemoryUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string entryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /vault/{id}/memory</c>, but is otherwise the
    /// same as <see cref="IMemoryService.List(MemoryListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemoryListResponse>> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemoryListParams, CancellationToken)"/>
    Task<HttpResponse<MemoryListResponse>> List(
        string id,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /vault/{id}/memory/{entryId}</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Delete(MemoryDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MemoryDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string entryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /vault/{id}/memory/search</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Search(MemorySearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemorySearchResponse>> Search(
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Search(MemorySearchParams, CancellationToken)"/>
    Task<HttpResponse<MemorySearchResponse>> Search(
        string id,
        MemorySearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
