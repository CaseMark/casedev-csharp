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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVaultService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGraphragService Graphrag { get; }

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
    Task Retrieve(VaultRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(VaultRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string id,
        VaultRetrieveParams? parameters = null,
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
    /// Triggers OCR ingestion workflow for a vault object to extract text, generate
    /// chunks, and create embeddings. Processing happens asynchronously with GraphRAG
    /// support if enabled on the vault. Returns immediately with workflow tracking information.
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
    /// This endpoint creates a temporary upload URL that allows secure file uploads
    /// without exposing credentials. Files can be automatically indexed for semantic
    /// search or stored for manual processing.
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
