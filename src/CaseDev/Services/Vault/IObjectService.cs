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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IObjectServiceWithRawResponse WithRawResponse { get; }

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
    Task<ObjectRetrieveResponse> Retrieve(
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ObjectRetrieveParams, CancellationToken)"/>
    Task<ObjectRetrieveResponse> Retrieve(
        string objectID,
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a document's filename, path, or metadata. Use this to rename files
    /// or organize them into virtual folders. The path is stored in metadata.path
    /// and can be used to build folder hierarchies in your application.
    /// </summary>
    Task<ObjectUpdateResponse> Update(
        ObjectUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ObjectUpdateParams, CancellationToken)"/>
    Task<ObjectUpdateResponse> Update(
        string objectID,
        ObjectUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all objects stored in a specific vault, including document metadata,
    /// ingestion status, and processing statistics.
    /// </summary>
    Task<ObjectListResponse> List(
        ObjectListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ObjectListParams, CancellationToken)"/>
    Task<ObjectListResponse> List(
        string id,
        ObjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a document from the vault including all associated vectors,
    /// chunks, graph data, and the original file. This operation cannot be undone.
    /// </summary>
    Task<ObjectDeleteResponse> Delete(
        ObjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ObjectDeleteParams, CancellationToken)"/>
    Task<ObjectDeleteResponse> Delete(
        string objectID,
        ObjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate presigned URLs for direct S3 operations (GET, PUT, DELETE, HEAD)
    /// on vault objects. This allows secure, time-limited access to files without
    /// proxying through the API. Essential for large document uploads/downloads in
    /// legal workflows.
    /// </summary>
    Task<ObjectCreatePresignedUrlResponse> CreatePresignedUrl(
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePresignedUrl(ObjectCreatePresignedUrlParams, CancellationToken)"/>
    Task<ObjectCreatePresignedUrlResponse> CreatePresignedUrl(
        string objectID,
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Downloads a file from a vault. Returns the actual file content as a binary
    /// stream with appropriate headers for file download. Useful for retrieving
    /// contracts, depositions, case files, and other legal documents stored in your vault.
    /// </summary>
    Task<BinaryContent> Download(
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(ObjectDownloadParams, CancellationToken)"/>
    Task<BinaryContent> Download(
        string objectID,
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves word-level OCR bounding box data for a processed PDF document. Each
    /// word includes its text, normalized bounding box coordinates (0-1 range),
    /// confidence score, and global word index. Use this data to highlight specific
    /// text ranges in a PDF viewer based on word indices from search results.
    /// </summary>
    Task<ObjectGetOcrWordsResponse> GetOcrWords(
        ObjectGetOcrWordsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetOcrWords(ObjectGetOcrWordsParams, CancellationToken)"/>
    Task<ObjectGetOcrWordsResponse> GetOcrWords(
        string objectID,
        ObjectGetOcrWordsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the status of a CaseMark summary workflow job.
    /// </summary>
    Task<ObjectGetSummarizeJobResponse> GetSummarizeJob(
        ObjectGetSummarizeJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSummarizeJob(ObjectGetSummarizeJobParams, CancellationToken)"/>
    Task<ObjectGetSummarizeJobResponse> GetSummarizeJob(
        string jobID,
        ObjectGetSummarizeJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the full extracted text content from a processed vault object. Returns
    /// the concatenated text from all chunks, useful for document review, analysis,
    /// or export. The object must have completed processing before text can be retrieved.
    /// </summary>
    Task<ObjectGetTextResponse> GetText(
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetText(ObjectGetTextParams, CancellationToken)"/>
    Task<ObjectGetTextResponse> GetText(
        string objectID,
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IObjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IObjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IObjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/objects/{objectId}`, but is otherwise the
    /// same as <see cref="IObjectService.Retrieve(ObjectRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectRetrieveResponse>> Retrieve(
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ObjectRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ObjectRetrieveResponse>> Retrieve(
        string objectID,
        ObjectRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /vault/{id}/objects/{objectId}`, but is otherwise the
    /// same as <see cref="IObjectService.Update(ObjectUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectUpdateResponse>> Update(
        ObjectUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ObjectUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ObjectUpdateResponse>> Update(
        string objectID,
        ObjectUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/objects`, but is otherwise the
    /// same as <see cref="IObjectService.List(ObjectListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectListResponse>> List(
        ObjectListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ObjectListParams, CancellationToken)"/>
    Task<HttpResponse<ObjectListResponse>> List(
        string id,
        ObjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /vault/{id}/objects/{objectId}`, but is otherwise the
    /// same as <see cref="IObjectService.Delete(ObjectDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectDeleteResponse>> Delete(
        ObjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ObjectDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ObjectDeleteResponse>> Delete(
        string objectID,
        ObjectDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /vault/{id}/objects/{objectId}/presigned-url`, but is otherwise the
    /// same as <see cref="IObjectService.CreatePresignedUrl(ObjectCreatePresignedUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectCreatePresignedUrlResponse>> CreatePresignedUrl(
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePresignedUrl(ObjectCreatePresignedUrlParams, CancellationToken)"/>
    Task<HttpResponse<ObjectCreatePresignedUrlResponse>> CreatePresignedUrl(
        string objectID,
        ObjectCreatePresignedUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/objects/{objectId}/download`, but is otherwise the
    /// same as <see cref="IObjectService.Download(ObjectDownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BinaryContent>> Download(
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(ObjectDownloadParams, CancellationToken)"/>
    Task<HttpResponse<BinaryContent>> Download(
        string objectID,
        ObjectDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/objects/{objectId}/ocr-words`, but is otherwise the
    /// same as <see cref="IObjectService.GetOcrWords(ObjectGetOcrWordsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectGetOcrWordsResponse>> GetOcrWords(
        ObjectGetOcrWordsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetOcrWords(ObjectGetOcrWordsParams, CancellationToken)"/>
    Task<HttpResponse<ObjectGetOcrWordsResponse>> GetOcrWords(
        string objectID,
        ObjectGetOcrWordsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/objects/{objectId}/summarize/{jobId}`, but is otherwise the
    /// same as <see cref="IObjectService.GetSummarizeJob(ObjectGetSummarizeJobParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectGetSummarizeJobResponse>> GetSummarizeJob(
        ObjectGetSummarizeJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSummarizeJob(ObjectGetSummarizeJobParams, CancellationToken)"/>
    Task<HttpResponse<ObjectGetSummarizeJobResponse>> GetSummarizeJob(
        string jobID,
        ObjectGetSummarizeJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /vault/{id}/objects/{objectId}/text`, but is otherwise the
    /// same as <see cref="IObjectService.GetText(ObjectGetTextParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectGetTextResponse>> GetText(
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetText(ObjectGetTextParams, CancellationToken)"/>
    Task<HttpResponse<ObjectGetTextResponse>> GetText(
        string objectID,
        ObjectGetTextParams parameters,
        CancellationToken cancellationToken = default
    );
}
