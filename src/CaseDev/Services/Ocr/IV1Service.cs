using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using V1 = CaseDev.Models.Ocr.V1;

namespace CaseDev.Services.Ocr;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve the status and results of an OCR job. Returns job progress, extracted
    /// text, and metadata when processing is complete.
    /// </summary>
    Task<V1::V1RetrieveResponse> Retrieve(
        V1::V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1::V1RetrieveParams, CancellationToken)"/>
    Task<V1::V1RetrieveResponse> Retrieve(
        string id,
        V1::V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download OCR processing results in various formats. Returns the processed
    /// document as text extraction, structured JSON with coordinates, searchable
    /// PDF with text layer, or the original uploaded document.
    /// </summary>
    Task<BinaryContent> Download(
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(V1::V1DownloadParams, CancellationToken)"/>
    Task<BinaryContent> Download(
        ApiEnum<string, V1::Type> type,
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit a document for OCR processing to extract text, detect tables, forms,
    /// and other features. Supports PDFs, images, and scanned documents. Returns
    /// a job ID that can be used to track processing status.
    /// </summary>
    Task<V1::V1ProcessResponse> Process(
        V1::V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /ocr/v1/{id}`, but is otherwise the
    /// same as <see cref="IV1Service.Retrieve(V1::V1RetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1::V1RetrieveResponse>> Retrieve(
        V1::V1RetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(V1::V1RetrieveParams, CancellationToken)"/>
    Task<HttpResponse<V1::V1RetrieveResponse>> Retrieve(
        string id,
        V1::V1RetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /ocr/v1/{id}/download/{type}`, but is otherwise the
    /// same as <see cref="IV1Service.Download(V1::V1DownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BinaryContent>> Download(
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(V1::V1DownloadParams, CancellationToken)"/>
    Task<HttpResponse<BinaryContent>> Download(
        ApiEnum<string, V1::Type> type,
        V1::V1DownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /ocr/v1/process`, but is otherwise the
    /// same as <see cref="IV1Service.Process(V1::V1ProcessParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1::V1ProcessResponse>> Process(
        V1::V1ProcessParams parameters,
        CancellationToken cancellationToken = default
    );
}
