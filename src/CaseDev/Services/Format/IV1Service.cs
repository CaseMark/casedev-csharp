using System;
using System.Threading;
using System.Threading.Tasks;
using CaseDev.Core;
using CaseDev.Models.Format.V1;
using V1 = CaseDev.Services.Format.V1;

namespace CaseDev.Services.Format;

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

    V1::ITemplateService Templates { get; }

    /// <summary>
    /// Convert Markdown, JSON, or text content to professionally formatted PDF,
    /// DOCX, or HTML documents. Supports template components with variable interpolation
    /// for creating consistent legal documents like contracts, briefs, and reports.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> CreateDocument(
        V1CreateDocumentParams parameters,
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

    V1::ITemplateServiceWithRawResponse Templates { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /format/v1/document`, but is otherwise the
    /// same as <see cref="IV1Service.CreateDocument(V1CreateDocumentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> CreateDocument(
        V1CreateDocumentParams parameters,
        CancellationToken cancellationToken = default
    );
}
