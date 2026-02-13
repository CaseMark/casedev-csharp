using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Vault;
using CaseDev.Services.Vault;

namespace CaseDev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVaultService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVaultServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVaultService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEventService Events { get; }

    IGraphragService Graphrag { get; }

    IMultipartService Multipart { get; }

    IObjectService Objects { get; }

    /// <summary>
    /// Creates a new secure vault with dedicated S3 storage and vector search capabilities.
    /// Each vault provides isolated document storage with semantic search, OCR processing,
    /// and optional GraphRAG knowledge graph features for legal document analysis
    /// and discovery.
    /// </summary>
    Task<VaultCreateResponse> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information about a specific vault, including storage configuration,
    /// chunking strategy, and usage statistics. Returns vault metadata, bucket information,
    /// and vector storage details.
    /// </summary>
    Task<VaultRetrieveResponse> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VaultRetrieveParams, CancellationToken)"/>
    Task<VaultRetrieveResponse> Retrieve(
        string id,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update vault settings including name, description, and enableGraph. Changing
    /// enableGraph only affects future document uploads - existing documents retain
    /// their current graph/non-graph state.
    /// </summary>
    Task<VaultUpdateResponse> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(VaultUpdateParams, CancellationToken)"/>
    Task<VaultUpdateResponse> Update(
        string id,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all vaults for the authenticated organization. Returns vault metadata
    /// including name, description, storage configuration, and usage statistics.
    /// </summary>
    Task<VaultListResponse> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a vault and all its contents including documents, vectors,
    /// graph data, and S3 buckets. This operation cannot be undone. For large vaults,
    /// use the async=true query parameter to queue deletion in the background.
    /// </summary>
    Task<VaultDeleteResponse> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VaultDeleteParams, CancellationToken)"/>
    Task<VaultDeleteResponse> Delete(
        string id,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Confirm whether a direct-to-S3 vault upload succeeded or failed. This endpoint
    /// emits vault.upload.completed or vault.upload.failed events and is idempotent
    /// for repeated confirmations.
    /// </summary>
    Task<VaultConfirmUploadResponse> ConfirmUpload(
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ConfirmUpload(VaultConfirmUploadParams, CancellationToken)"/>
    Task<VaultConfirmUploadResponse> ConfirmUpload(
        string objectID,
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Triggers ingestion workflow for a vault object to extract text, generate chunks,
    /// and create embeddings. For supported file types (PDF, DOCX, TXT, RTF, XML,
    /// audio, video), processing happens asynchronously. For unsupported types (images,
    /// archives, etc.), the file is marked as completed immediately without text
    /// extraction. GraphRAG indexing must be triggered separately via POST /vault/:id/graphrag/:objectId.
    /// </summary>
    Task<VaultIngestResponse> Ingest(
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Ingest(VaultIngestParams, CancellationToken)"/>
    Task<VaultIngestResponse> Ingest(
        string objectID,
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search across vault documents using multiple methods including hybrid vector
    /// + graph search, GraphRAG global search, entity-based search, and fast similarity
    /// search. Returns relevant documents and contextual answers based on the search method.
    /// </summary>
    Task<VaultSearchResponse> Search(
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Search(VaultSearchParams, CancellationToken)"/>
    Task<VaultSearchResponse> Search(
        string id,
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate a presigned URL for uploading files directly to a vault's S3 storage.
    /// After uploading to S3, confirm the upload result via POST /vault/:vaultId/upload/:objectId/confirm
    /// before triggering ingestion.
    /// </summary>
    Task<VaultUploadResponse> Upload(
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(VaultUploadParams, CancellationToken)"/>
    Task<VaultUploadResponse> Upload(
        string id,
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVaultService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVaultServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVaultServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEventServiceWithRawResponse Events { get; }

    IGraphragServiceWithRawResponse Graphrag { get; }

    IMultipartServiceWithRawResponse Multipart { get; }

    IObjectServiceWithRawResponse Objects { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /vault`, but is otherwise the
    /// same as <see cref="IVaultService.Create(VaultCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultCreateResponse>> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}`, but is otherwise the
    /// same as <see cref="IVaultService.Retrieve(VaultRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultRetrieveResponse>> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VaultRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VaultRetrieveResponse>> Retrieve(
        string id,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /vault/{id}`, but is otherwise the
    /// same as <see cref="IVaultService.Update(VaultUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultUpdateResponse>> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(VaultUpdateParams, CancellationToken)"/>
    Task<HttpResponse<VaultUpdateResponse>> Update(
        string id,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault`, but is otherwise the
    /// same as <see cref="IVaultService.List(VaultListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultListResponse>> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /vault/{id}`, but is otherwise the
    /// same as <see cref="IVaultService.Delete(VaultDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultDeleteResponse>> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VaultDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VaultDeleteResponse>> Delete(
        string id,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/upload/{objectId}/confirm`, but is otherwise the
    /// same as <see cref="IVaultService.ConfirmUpload(VaultConfirmUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultConfirmUploadResponse>> ConfirmUpload(
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ConfirmUpload(VaultConfirmUploadParams, CancellationToken)"/>
    Task<HttpResponse<VaultConfirmUploadResponse>> ConfirmUpload(
        string objectID,
        VaultConfirmUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/ingest/{objectId}`, but is otherwise the
    /// same as <see cref="IVaultService.Ingest(VaultIngestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultIngestResponse>> Ingest(
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Ingest(VaultIngestParams, CancellationToken)"/>
    Task<HttpResponse<VaultIngestResponse>> Ingest(
        string objectID,
        VaultIngestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/search`, but is otherwise the
    /// same as <see cref="IVaultService.Search(VaultSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultSearchResponse>> Search(
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Search(VaultSearchParams, CancellationToken)"/>
    Task<HttpResponse<VaultSearchResponse>> Search(
        string id,
        VaultSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/upload`, but is otherwise the
    /// same as <see cref="IVaultService.Upload(VaultUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultUploadResponse>> Upload(
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(VaultUploadParams, CancellationToken)"/>
    Task<HttpResponse<VaultUploadResponse>> Upload(
        string id,
        VaultUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
