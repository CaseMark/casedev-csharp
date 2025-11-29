using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Vault.Objects;

namespace CaseDev.Services.Vault;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IObjectService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IObjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves metadata for a specific document in a vault and generates a temporary
    /// download URL. The download URL expires after 1 hour for security. This endpoint
    /// also updates the file size if it wasn't previously calculated.
    /// </summary>
    Task Retrieve(ObjectRetrieveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Retrieve(ObjectRetrieveParams, CancellationToken)"/>
    Task Retrieve(
        string objectID,
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all objects stored in a specific vault, including document metadata,
    /// ingestion status, and processing statistics.
    /// </summary>
    Task List(ObjectListParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="List(ObjectListParams, CancellationToken)"/>
    Task List(
        string id,
        ObjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate presigned URLs for direct S3 operations (GET, PUT, DELETE, HEAD)
    /// on vault objects. This allows secure, time-limited access to files without
    /// proxying through the API. Essential for large document uploads/downloads in
    /// legal workflows.
    /// </summary>
    Task<ObjectCreatePresignedURLResponse> CreatePresignedURL(
        ObjectCreatePresignedURLParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePresignedURL(ObjectCreatePresignedURLParams, CancellationToken)"/>
    Task<ObjectCreatePresignedURLResponse> CreatePresignedURL(
        string objectID,
        ObjectCreatePresignedURLParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads a file from a vault. Returns the actual file content as a binary
    /// stream with appropriate headers for file download. Useful for retrieving
    /// contracts, depositions, case files, and other legal documents stored in your vault.
    /// </summary>
    Task Download(ObjectDownloadParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Download(ObjectDownloadParams, CancellationToken)"/>
    Task Download(
        string objectID,
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the full extracted text content from a processed vault object. Returns
    /// the concatenated text from all chunks, useful for document review, analysis,
    /// or export. The object must have completed processing before text can be retrieved.
    /// </summary>
    Task GetText(ObjectGetTextParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="GetText(ObjectGetTextParams, CancellationToken)"/>
    Task GetText(
        string objectID,
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    );
}
